//Vue 2
/*
let app = new Vue({
    el: '#pageId',
    data: {
        message: `Vue works!`,
        event: [],
    },
    mounted: function () {
        this.fetchEvents();
    },
    methods: {
        fetchEvents: async function () {
            console.log("chiamo fetch")
            let prova = await fetch('/Main/Main/GetData')
                .then(response => {
                    if (!response.ok) {
                        console.log(response.statusText)
                        throw new Error('Network response was not ok ');
                    }
                    return response.json();
                })
                .then(data => {

                    this.event = data
                    console.log("data", data)
                    console.log("this.event",this.event)

                    for (let i = 0; i < 5; i++) {
                        const day = this.previousFirstDayOfWeek.addDays(i).format()
                        data.forEach(x => {
                            this.event.push(
                                {
                                    start: `${day} ${x.startTime}`,
                                    end: `${day} ${x.endTime}`,
                                    class: x.cssClass,
                                    title: x.Title
                                })
                        })
                    }

                    console.log("data", data[0].start)
                    console.log("this.event", this.event)

                })
                .catch(
                    error => {
                        console.error('Unable to get events')
                        console.log(error)
                    }
                );
        }
    },
    computed: {
        // Get the Monday of the real time current week.
        previousFirstDayOfWeek() {
            return new Date(new Date().setDate(new Date().getDate() - (new Date().getDay() + 6) % 7))
        }
    },
    created() {
        // Place all the events in the real time current week.
        for (let i = 0; i < 5; i++) {
            const day = this.previousFirstDayOfWeek.addDays(i).format()
            console.log("day vale =", day)

            this.event.push(
                {
                    start: `${day} 13:00`,
                    end: `${day} 14:00`,
                    title: 'LUNCH',
                    class: 'lunch',
                    background: true,
                    deletable: false,
                    resizable: false,
                    //split: 1
                },
                {
                    start: `${day} 13:00`,
                    end: `${day} 14:00`,
                    title: 'LUNCH',
                    class: 'lunch',
                    background: true,
                    deletable: false,
                    resizable: false,
                    //split: 2
                }
            )
        }
        console.log(this.event)
    },
    components: {
        "vue-cal": vuecal,

    }

})
})
*/
//console.log(VueCal)
////Vue 3
const app = Vue.createApp({
    data() {
        return {
            message: `Vue works!`,
            activeView: "week",
            selectedEvent: [],
            singleDay: false,
            showDialog: false,
            event: [],
        };
    },
    mounted() {
        this.fetchEvents();
    },
    methods: {
        async fetchEvents() {
            console.log("chiamo fetch");
            await fetch('/Main/Main/GetData')
                .then(response => {
                if (!response.ok) {
                    console.log(response.statusText);
                    throw new Error('Network response was not ok ');
                }
                return response.json();
            })
                .then(data => {
                console.log("data", data);
                //come prova inserisco manualmente l'unico evento nel db per tutti i giorni della settimana corrente
                for (let i = 0; i < 5;) {
                    const day = this.previousFirstDayOfWeek.addDays(i).format();
                    data.forEach(x => {
                        //pusho gli eventi presi dal backend
                        this.event.push({
                            // questi sono i parametri che il componente si aspetta per gli eventi
                            start: `${day} ${x.startTime}`, //questo è dataInizio + orario dell'evento
                            end: `${day} ${x.endTime}`,
                            title: x.Title,
                            content: x.content,
                            class: x.cssClass,
                            background: x.background,
                            spli: x.split,
                            allDay: x.allDay,
                            deletable: x.deletable,
                            resizable: x.resizable,
                            //da qui in poi i valori che uso localmente, quindi non richiesti dal componente ma che mi servono per visualizzarli al click
                            id: x.id,
                            startDate: x.startDate,
                            startTime: x.starTime,
                        });
                    });
                    i++;
                }
                //console.log("data", data[0].start)
                console.log("this.event", this.event);
            })
                .catch(error => {
                console.error('Unable to get events');
                console.log(error);
            });
        },
        onEventClickOld(event, e) {
            //Reindirizzamento alla pagina con il singolo giorno
            //fetch(globalModelData)
            //console.log("globalModelData", globalModelData) // ho i dati dell'evento che ho appena cliccato
            console.log(event); // ho i dati dell'evento che ho appena cliccato
            console.log(e); // errore
            //window.location.href = '/Main/SingleDay';
        },
        async onEventClick(event, e) {
            console.log("sono in andiamo event", event);
            this.selectedEvent = event;
            this.showDialog = true;
            e.stopPropagation();
            // Seleziona l'elemento basato sull'ID o sulla classe
            //const element = document.querySelector('.vuecal__flex.vuecal');
            //if (element) {
            //    // Rimuovi la classe 'vuecal--week-view'
            //    element.classList.remove('vuecal--week-view');
            //    console.log("ho rimosso",element.classList)
            //    // Aggiungi la classe 'vuecal--day-view'
            //    element.classList.add('vuecal--day-view');
            //    console.log("ho aggiunto",element.classList)
            //}
            //this.activeView = 'day'
            //await fetch('/Main/Main/SingleDay')
            // Prevent navigating to narrower view (default vue-cal behavior).
        }
    },
    computed: {
        // Get the Monday of the real time current week.
        previousFirstDayOfWeek() {
            return new Date(new Date().setDate(new Date().getDate() - (new Date().getDay() + 6) % 7));
        }
    },
    created() {
        // Inserisco l'evento lunch in tutte i giorni della settimana corrente
        for (let i = 0; i < 5; i++) {
            const day = this.previousFirstDayOfWeek.addDays(i).format();
            //console.log("day vale =", day)
            this.event.push({
                start: `${day} 13:00`,
                end: `${day} 14:00`,
                title: 'LUNCH',
                class: 'lunch',
                background: true,
                deletable: false,
                resizable: false,
            });
        }
        //console.log(globalModelData)
        //console.log(this.event)
    },
});
app.component('vue-cal', vuecal);
app.mount('#pageId');
// Esporta l'istanza di Vue per un uso esterno
//export default app;
//# sourceMappingURL=main.js.map