declare var Vue: any;
declare var vuecal: any;
declare var mainModel: any; //variabile globale che rappresenta il mainViewModel

const app = Vue.createApp({
    data() {
        return {
            //parametri che gestiscono l'oggetto da modificare e la visualizzazione dei campi nel form
            inputToDisplay: {
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
            } as { [key: string]: boolean },
            inputType: {} as { [key: string]: boolean },
            toModify: {
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
            } as { [key: string]: boolean },
            toModifykeys: null, //oggetto che contiene solo le chiavi dell'oggetto da modificare

            //parametri 'interni'
            prova: "",
            dataNew: "",
            model: mainModel, //oggetto model locale, da poter modificare
            mostraSettimana: true,
            mostraGiorno: false,
            message: `Vue works!`,
            activeView: "week", //la vista attiva, fra day e week
            selectedDate: "",
            customClass: "col", //classe custom per ridurre la larghezza quando si seleziona activeView=day

            selectedEvent: null,
            showEditForm: false,

            showEventCreationDialog: false, //eventuale per gestire creazione evento con vuecal

            showSingleDay: false,
            event: [], //eventi presi dal backend


            key: "",
            //variabili locali per scegliere orari nel menu a tendina dall'array ore
            oraInizio: 0,
            oraFine: 0,
            ore: Array.from({ length: 24 }, (_, i) => i), // Array di 24 ore

            dataEvento: null,

        };
    },

    mounted() {
        //setto gli eventi
        //console.log("this.mainModel", this.mainModel)
        this.setEvents()
    },
    methods: {
        //visualizzo sulla destra gli eventi per il giorno selezionato
        async setDataByDate(dataScelta) {
            const url = `/Main/Main/GetData?dataScelta=${encodeURIComponent(dataScelta)}`;

            try {
                const response = await fetch(url);
                if (!response.ok) {
                    throw new Error(`Network response was not ok, status: ${response.status}`);
                }
                const data = await response.json();

                this.model = data
                //console.log("this.model.ferie..lenght", this.model.ferie.ferie.length)

            }
            catch (error) {
                console.error('Unable to get events', error);
                throw new Error(`Network response was not ok, error: ${error}`);
            }
        },

        //metodo per settare gli eventi del backend nel calendario vue-cal
        setEvents() {
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
            //console.log("ho cliccato sulla settimana")

            this.mostraGiorno = false;
            this.mostraSettimana = true;
            this.showSingleDay = false

            this.customClass = "col"
            this.activeView = "week";

        },

        //metodo per gestire cosa succede se si sceglie di visualizzare un giorno, idGiorno è il giorno scelto
        async selezionaGiorno(idGiorno) {
            this.selectedDate = idGiorno
            this.dataNew = idGiorno
            await this.setDataByDate(this.selectedDate)

            this.mostraSettimana = false;
            this.mostraGiorno = true;
            this.customClass = "col-2"
            this.showSingleDay = true
            this.activeView = "day";
        },

        onEventClick(event, e) {
            this.selectedEvent = event
            console.log("this.selectedEvent", this.selectedEvent)
            e.stopPropagation()
        },

        //metodo per comprendere il tipo di dato dal suo valore (string, number, boolean, date)
        getInputType(value, key) {
            if (typeof value === 'number') {
                return 'number';
            }
            else if (typeof value === 'boolean') {
                return 'boolean'
            }
            else if (this.isDate(value)) {
                //yyy-MM-dd

                const date = new Date(value);
                const year = date.getFullYear();
                // getMonth() restituisce un valore da 0 (gennaio) a 11 (dicembre), quindi aggiungi 1 per ottenere il mese corretto
                const month = (date.getMonth() + 1).toString().padStart(2, '0'); // Aggiungi uno zero iniziale se necessario
                const day = date.getDate().toString().padStart(2, '0'); // Aggiungi uno zero iniziale se necessario

                const formattedDate = `${year}-${month}-${day}`;
                this.toModify[key] = formattedDate;
                //return formattedDate; // Restituisce la data formattata
                return 'date';
            }
            else if (value === null || typeof value === 'string') {
                return 'text';
            }
        },

        //metodo per comprendere se il valore può essere un valore valido di data
        isDate(value) {
            return !isNaN(Date.parse(value));
        },

        //metodo che gestisce la logica per raggiungere il form (in creazione e in modifica)
        async navigateToEdit(id, nome, data) {

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
                        this.inputType[key] = this.getInputType(this.toModify[key], key)
                    });

                    this.showSingleDay = false;
                    this.showEditForm = true
                })
                .catch((error) => {
                    console.error('Unable to get events', error);
                    throw new Error(`Network response was not ok, error: ${error}`);
                })

        },

        creaEvento() {
            this.showSingleDay = false;

            this.showEventCreationDialog = true

        },
        //    this.$refs.vuecal.createEvent(
        //        {
        //            startDate: feria.DataInizio.ToString("d"),
        //            StartTime = feria.DataInizio.ToString("d"),
        //            EndDate = feria.DataFine.ToString("d"),
        //            EndTime = feria.DataFine.ToString("d"),
        //            Title = feria.Dettagli,
        //            Content = feria.Dettagli,
        //            CssClass = feria.Class,
        //            AllDay = true,
        //            Background = false,
        //            Deletable = true,
        //            Resizable = true,
        //        }
        //    )
        //},

        onEventCreate(event, deleteEventFunction) {
            this.selectedEvent = event
            this.showEventCreationDialog = true
            this.deleteEventFunction = deleteEventFunction

            return event
        },

        cancelEventCreation() {
            this.closeCreationDialog()
            this.deleteEventFunction()
        },
        closeCreationDialog() {
            this.showEventCreationDialog = false
            this.selectedEvent = {}
        },

        inserisciOra() {
            this.toModify['oraInizio'] = this.creaDateTime(this.oraInizio);            
            this.toModify['oraFine'] = this.creaDateTime(this.oraFine);
        },
        //
        creaDateTime(ora) {
            this.dataEvento = new Date(this.dataNew);

            let dateTime = this.dataEvento; // Crea una copia della data di base

            dateTime.setHours(ora, 0, 0); // Imposta l'ora e azzera minuti e secondi

            //console.log("dateTime = ", dateTime)

            return dateTime
        },
        
        capitalizeFirstLetter(string) {
            return string.charAt(0).toUpperCase() + string.slice(1);
        },

        transformKeysToCapitalize(object) {
            const capitalizedObject = {};
            Object.keys(object).forEach(key => {
                const capitalizedKey = this.capitalizeFirstLetter(key);
                capitalizedObject[capitalizedKey] = object[key];
            });
            return capitalizedObject;
        },


        async modify() {
            const toModifyCapitalized = this.transformKeysToCapitalize(this.toModify);
            
            const url = `/Rendicontazioni/Rendicontazioni/Edit`
            await fetch(url, {
                method: "POST",
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify(toModifyCapitalized),
            });
        },

    },

    computed: {
        // Get the Monday of the real time current week.
        previousFirstDayOfWeek() {
            return new Date(new Date().setDate(new Date().getDate() - (new Date().getDay() + 6) % 7))
        },
        //alla modifica di uno dei parametri oraInizio, oraFine calcolo oreTotali (nell'oggetto da modificare) --> vedere watch
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
            this.inserisciOra(); // Invoca qui inserisciOra quando oreTotali cambia
        }
    },
    components: {
        'vue-cal': vuecal,
    }
});

app.mount('#pageId');