//import Vue = require("../../node_modules/vue/types/umd");
//import vuecal = require("../../node_modules/vue-cal/dist/vuecal.umd.js")
//import Vue from 'vue';
//import vuecal from 'vue-cal';
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
        fetchEvents: function () {
            fetch('/Main/Main/GetData')
                .then(response => {
                if (!response.ok) {
                    console.log(response.statusText);
                    throw new Error('Network response was not ok ');
                }
                return response.json();
            })
                .then(data => {
                this.event = data;
                console.log("data", data);
                console.log("this.event", this.event);
            })
                .catch(error => {
                console.error('Unable to get events');
                console.log(error);
            });
        }
    },
    components: {
        "vue-cal": vuecal,
    }
});
export default app;
//# sourceMappingURL=main.js.map