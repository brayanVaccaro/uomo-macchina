declare var Vue: any;
declare var vuecal: any;
declare var mainModel: any; //variabile globale che rappresenta il mainViewModel
declare var annoDati: any
var currentMonthIndex = new Date().getMonth(); // 0-11 for Jan-Dec

////Vue 3
const app = Vue.createApp({

    data() {
        return {
            //parametri che gestiscono l'oggetto da modificare e la visualizzazione dei campi nel form
            inputToDisplay: {
                //'id': false,
                'data': false,
                'dataInizio': false,
                'dataFine': false,
                'durata': false,
                'oreTotali': false,
                'oraInizio': false,
                'oraFine': false,
                'commessa': false,
                'dettagli': false,
                'tipoViaggio': false,
                'chilometri': false,
                'autoAziendale': false,
                'importo': false,
                'cartaAziendale': false,
                'straordinario': false
            } as { [key: string]: boolean },
            toModify: {} as { [key: string]: boolean },
            toModifykeys: null, //oggetto che contiene solo le chiavi dell'oggetto da modificare
            toModifyName: "",//nome dell'oggetto da modificare

            //parametri 'interni'
            dataNew: "",
            filterDate: "",
            filterCommessa: "",
            filterDettagli: "",
            model: mainModel, //oggetto model locale, da poter modificare
            
            activeView: "week", //la vista attiva, fra day e week
            selectedDate: "",
            customClass: "col", //classe custom per ridurre la larghezza quando si seleziona activeView=day
            custom: "", //classe per nascondere time-cell-labels in vue-cal

            showEditForm: false,
            showSingleDay: false,
            event: [], //eventi presi dal backend

            key: "",
            //variabili locali per scegliere orari nel menu a tendina dall'array ore
            oraInizio: 0,
            oraFine: 0,
            ore: Array.from({ length: 24 }, (_, i) => i), // Array di 24 ore

        };
    },

    mounted() {
        //setto gli eventi
        this.setEvents()
    },
    methods: {

        pluraleASingolare(parola) {//mostra il nome giusto in crezione e modifica

            switch (parola) {
                case 'Rendicontazioni':
                    parola = 'Rendicontazione'
                    break;
                case 'Ferie':
                    parola = 'Feria'
                    break;
                case 'Permessi':
                    parola = 'Permesso'
                    break;
                case 'Trasferte':
                    parola = 'Trasferta'
                    break;
                case 'NottiFuori':
                    parola = 'Notte Fuori'
                    break;
                case 'Rimborsi':
                    parola = 'Rimborso'
                    break;
                default:
                    return 'errore'
            }
            return parola;
        },

        updateMonthName(monthIndex) { //aggiorna il mese
            var monthName = annoDati.Mesi[monthIndex].NomeMese;
            document.getElementById('monthDisplay').innerText = monthName;
        },

        updateWeeksAndDays(monthIndex) {//aggiorna le settimane e i giorni
            var settimaneContainer = document.getElementById('settimaneContainer');
            settimaneContainer.innerHTML = ''; // Pulisce le settimane esistenti

            annoDati.Mesi[monthIndex].Settimane.forEach(function (settimana) {
                var weekElement = document.createElement('li'); // Creo un nuovo elemento di lista per la settimana
                weekElement.className = 'nav-item dropdown col'; // Imposto le classi necessarie

                var weekLink = document.createElement('a');
                weekLink.className = 'nav-link weekDisplay';
                weekLink.setAttribute('role', 'button');
                weekLink.setAttribute('data-bs-toggle', 'dropdown');
                weekLink.setAttribute('aria-expanded', 'false');
                weekLink.setAttribute('data-giorno', settimana.Giorni[0].split('T')[0]); // Salvo il primo giorno della settimana
                weekLink.innerText = settimana.Nome; // Imposto il nome della settimana

                weekElement.appendChild(weekLink);

                var daysList = document.createElement('ul');
                daysList.className = 'dropdown-menu row'; // Imposta le classi necessarie

                settimana.Giorni.forEach(function (giorno) {
                    var dayItem = document.createElement('li');
                    dayItem.className = 'dropdown-item dayDisplay'; // Imposta le classi necessarie
                    dayItem.setAttribute('data-giorno', giorno.split('T')[0])

                    var dayLink = document.createElement('a');
                    var giornoDate = new Date(giorno);
                    dayLink.innerText = giornoDate.toLocaleDateString('it-IT', { weekday: 'long', day: 'numeric' }); // Formatta e imposta il giorno
                    dayItem.appendChild(dayLink);

                    daysList.appendChild(dayItem); // Aggiunge il giorno alla lista dei giorni
                });

                weekElement.appendChild(daysList); // Aggiunge la lista dei giorni all'elemento della settimana
                settimaneContainer.appendChild(weekElement); // Aggiunge l'elemento della settimana al container delle settimane
            });
            this.aggiungiEventListeners()
        },

        aggiungiEventListeners() {// aggiunge event listener alle settimane e ai giorni
            const settimaneEl = document.querySelectorAll('.weekDisplay'); // Seleziona tutti i link delle settimane
            settimaneEl.forEach(el => {
                var settimanaEl = el as HTMLElement
                settimanaEl.addEventListener('click', () => {
                    const primoGiorno = el.getAttribute("data-giorno")
                    this.selezionaSettimana(primoGiorno)
                });
            });

            const giorniEl = document.querySelectorAll('.dayDisplay'); // Seleziona tutti gli elementi dei giorni
            giorniEl.forEach(el => {
                var giornoEl = el as HTMLElement
                giornoEl.addEventListener('click', () => {
                    const giorno = el.getAttribute("data-giorno")
                    this.selezionaGiorno(giorno)
                });
            });
        },

        prevMonth() {//click sulla freccia sinistra
            console.log("ho cliccato prevMonth")
            if (currentMonthIndex > 0) {
                currentMonthIndex--;
                this.updateMonthName(currentMonthIndex);
                this.updateWeeksAndDays(currentMonthIndex);
            }
        },

        nextMonth() {//click sulla freccia destra
            console.log("ho cliccato nextMonth")
            if (currentMonthIndex < annoDati.Mesi.length - 1) {
                currentMonthIndex++;
                this.updateMonthName(currentMonthIndex);
                this.updateWeeksAndDays(currentMonthIndex);
            }
        },

        /* Funzione del filtro setDataByDate */
        async setDataByDate(dataScelta) {
            const url = `/Main/Main/GetData?dataScelta=${encodeURIComponent(dataScelta)}`;

            try {
                const response = await fetch(url);
                if (!response.ok) {
                    throw new Error(`Network response was not ok, status: ${response.status}`);
                }
                const data = await response.json();

                this.model = data
                this.setEvents()
                console.log("this.model", this.model)

            }
            catch (error) {
                console.error('Unable to get events', error);
                throw new Error(`Network response was not ok, error: ${error}`);
            }
        },


        /* Funzione del filtro setCommessa */
        async setCommessa(commessaScelta, giornoSelezionato) {
            const url = `/Main/Main/GetAllByCommessa?commessaScelta=${encodeURIComponent(commessaScelta)}&giornoSelezionato=${encodeURIComponent(giornoSelezionato)}`;

            try {
                const response = await fetch(url);
                if (!response.ok) {
                    throw new Error(`Network response was not ok, status: ${response.status}`);
                }
                const data = await response.json();

                this.model = data


            }
            catch (error) {
                console.error('Unable to get events', error);
                throw new Error(`Network response was not ok, error: ${error}`);
            }
        },


        /* Funzione del filtro setDettagli */

        async setDettagli(dettaglioScelta, giornoSelezionato) {
            const url = `/Main/Main/GetAllByDettaglio?dettaglioScelta=${encodeURIComponent(dettaglioScelta)}&giornoSelezionato=${encodeURIComponent(giornoSelezionato)}`;

            try {
                const response = await fetch(url);
                if (!response.ok) {
                    throw new Error(`Network response was not ok, status: ${response.status}`);
                }
                const data = await response.json();

                this.model = data


            }
            catch (error) {
                console.error('Unable to get events', error);
                throw new Error(`Network response was not ok, error: ${error}`);
            }
        },


        //metodo per settare gli eventi del backend nel calendario vue-cal
        setEvents() {
            this.event = []
            this.model.eventi.eventi.forEach(x => {
                //pusho gli eventi presi dal backend
                this.event.push(
                    {
                        // questi sono i parametri che il componente si aspetta per gli eventi
                        start: `${x.startDate} ${x.startTime}`, //questo è dataInizio + orario dell'evento
                        end: `${x.endDate} ${x.endTime}`,
                        title: x.title,
                        content: x.content,
                        class: x.class,
                        background: x.background,
                        split: x.split,
                        allDay: x.allDay,
                        deletable: x.deletable,
                        resizable: x.resizable,
                        //da qui in poi i valori che uso localmente, quindi non richiesti dal componente ma che mi servono per visualizzarli al click
                        id: x.id,
                        startDate: x.startDate,
                        startTime: x.starTime,

                    })
            })
        },

        //metodo per gestire cosa succede se si sceglie di visualizzare una settimana
        selezionaSettimana(idSettimana) {
            this.selectedDate = idSettimana
            console.log("ho cliccato sulla settimana")

            this.showSingleDay = false

            this.customClass = "col"
            this.custom = ""
            this.activeView = "week";

        },

        //metodo per gestire cosa succede se si sceglie di visualizzare un giorno, idGiorno è il giorno scelto
        async selezionaGiorno(idGiorno) {
            this.selectedDate = idGiorno
            this.dataNew = idGiorno
            await this.setDataByDate(this.selectedDate)
            this.setEvents()
            this.customClass = "col-2"
            this.custom = "custom-hide-time-cell"
            this.showSingleDay = true //visualizzo le tabelle
            this.activeView = "day";
        },
        async annulla() {
            this.showEditForm = false
            await this.setDataByDate(this.dataNew)
            this.resetToDefault()
            this.showSingleDay = true
        },
        async elimina(id) {

            let nome = this.toModifyName;
            const url = `/${nome}/${nome}/Delete?id=${id}`
            await fetch(url, {
                method: "POST"
            })

            this.showEditForm = false


            await this.setDataByDate(this.dataNew)
            this.resetToDefault()
            this.showSingleDay = true
        },

        onEventClick(event, e) {
            this.selezionaGiorno(event.startDate)
            e.stopPropagation()
        },

        //metodo che gestisce la logica per raggiungere il form (in creazione e in modifica)
        async navigateToEdit(id, nome, data) {

            this.toModifyName = nome;
            const url = `/${nome}/${nome}/Edit?id=${id}&data=${data}`
            await fetch(url, {
                method: "GET",
            })
                .then((response) => {
                    const results = response.json();
                    return results;
                }).then((results) => {

                    this.toModify = results
                    this.toModifykeys = Object.keys(this.toModify)

                    this.toModifykeys.forEach((key: string) => {
                        this.inputToDisplay[key] = true;
                    });
                    this.showSingleDay = false;
                    this.showEditForm = true
                })
                .catch((error) => {
                    console.error('Unable to get events', error);
                    throw new Error(`Network response was not ok, error: ${error}`);
                })

        },
        async create() {

            const url = `/${this.toModifyName}/${this.toModifyName}/Edit`
            await fetch(url, {
                method: "POST",
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify(this.toModify),
            })
            this.showEditForm = false
            this.showSingleDay = true;
            this.resetToDefault();
            this.setDataByDate(this.dataNew);
        },
        resetToDefault() {
            //resetto inputToDisplay
            this.inputToDisplay = {
                'data': false,
                'dataInizio': false,
                'dataFine': false,
                'durata': false,
                'oreTotali': false,
                'oraInizio': false,
                'oraFine': false,
                'commessa': false,
                'dettagli': false,
                'tipoViaggio': false,
                'chilometri': false,
                'autoAziendale': false,
                'importo': false,
                'cartaAziendale': false
            };

            //resetto oraInizio e oraFine
            this.oraInizio = 0;
            this.oraFine = 0;

            this.toModify = {
                'data': false,
                'dataInizio': false,
                'dataFine': false,
                'durata': false,
                'oreTotali': false,
                'oraInizio': false,
                'oraFine': false,
                'commessa': false,
                'dettagli': false,
                'tipoViaggio': false,
                'chilometri': false,
                'autoAziendale': false,
                'importo': false,
                'cartaAziendale': false
            }
        },



    },

    computed: {
        // Get the Monday of the real time current week.
        previousFirstDayOfWeek() {
            return new Date(new Date().setDate(new Date().getDate() - (new Date().getDay() + 6) % 7))
        },
        //alla modifica di uno dei parametri oraInizio o oraFine calcolo oreTotali (nell'oggetto da modificare) --> vedere watch
        calcoloOreTotali() {
            if (this.toModify === null) return 0;
            if (this.oraInizio === 0 || this.oraFine === 0 || this.toModify["oreTotali"] == null) return 0;

            let inizio = parseInt(this.oraInizio, 10);
            let fine = parseInt(this.oraFine, 10);

            // Calcola la differenza
            this.toModify['oreTotali'] = fine - inizio;

            // Gestisci il passaggio da PM ad AM
            if (this.toModify['oreTotali'] < 0) {
                this.toModify['oreTotali'] += 24;
            }

            return this.toModify['oreTotali'];
        },

    },

    created() {

        // Inserisco l'evento lunch in tutte i giorni della settimana corrente
        for (let i = 0; i < 5; i++) {

            const day = this.previousFirstDayOfWeek.addDays(i).format()

            this.event.push(
                {
                    start: `${day} 13:00`,
                    end: `${day} 14:00`,
                    title: 'LUNCH',
                    class: 'lunch',
                    background: true,
                    deletable: false,
                    resizable: false,

                }
            )
        }
        // Inserisco in sabato e domenica il giorno feriale
        for (let i = 5; i <= 6; i++) {

            const day = this.previousFirstDayOfWeek.addDays(i).format();
            //console.log("day vale =", day)

            this.event.push({
                start: `${day} 13:00`,
                end: `${day} 14:00`,
                title: 'giorno feriale',
                class: 'libero',
                allDay: true,
                background: true,
                deletable: false,
                resizable: false,
            });
        }


    },
    watch: {
        //al cambio del valore del metodo calcoloOreTotali chiamo inserisciOra
        calcoloOreTotali(newValue) {
            console.log("Le ore totali sono cambiate, nuovo valore: ", newValue);

        }
    },
    components: {
        'vue-cal': vuecal,
    }
});

app.mount('#pageId');