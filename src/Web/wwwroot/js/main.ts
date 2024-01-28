declare var Vue: any;
declare var vuecal: any;
declare var mainModel: any; //variabile globale che rappresenta il mainViewModel

//accedo a @Model
////Vue 3
const app = Vue.createApp({

    data() {
        return {
            model: mainModel, //oggetto model locale, da poter modificare
            mostraSettimana: true,
            mostraGiorno: false,
            message: `Vue works!`,
            activeView: "week", //la vista attiva, fra day e week
            selectedDate: "",
            customClass: "col", //classe custom per ridurre la larghezza quando si seleziona activeView=day
            selectedEvent: [],
            singleDay: false,
            showSingleDay: false,
            event: [], //eventi presi dal backend
        };
    },
    mounted() {
        //setto gli eventi
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
                console.log("this.model.ferie..lenght", this.model.ferie.ferie.length)

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
            console.log("ho cliccato sulla settimana")

            this.mostraGiorno = false;
            this.mostraSettimana = true;
            this.showSingleDay = false

            this.customClass = "col"
            this.activeView = "week";

        },
        //metodo per gestire cosa succede se si sceglie di visualizzare un giorno, idGiorno è il giorno scelto
        async selezionaGiorno(idGiorno) {
            this.selectedDate = idGiorno
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
        }
    },
    computed: {
        // Get the Monday of the real time current week.
        previousFirstDayOfWeek() {
            return new Date(new Date().setDate(new Date().getDate() - (new Date().getDay() + 6) % 7))
        }
    },
    created() {
        // Inserisco l'evento lunch in tutte i giorni della settimana corrente
        for (let i = 0; i < 5; i++) {

            const day = this.previousFirstDayOfWeek.addDays(i).format()
            //console.log("day vale =", day)

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
    components: { 'vue-cal': vuecal }
});

app.mount('#pageId');
