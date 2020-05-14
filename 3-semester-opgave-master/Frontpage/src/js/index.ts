import axios, {
    AxiosResponse,
    AxiosError
} from "../../node_modules/axios/index"

interface Booking {
    flightNr: string;
    departingFrom: string;
    destination: string;
    distance:number;
    travelTime: number;
    stopOver: string;
    company: string;
    capacity: number;
    fuelConsumption:number;
}


<<<<<<< Updated upstream:Frontpage/src/js/index.ts
let baseUri: string = "https://flybooking2202.azurewebsites.net/api/localFlights"
=======
let baseUri: string = "https://flightbookinginmemdb2020.azurewebsites.net/api/Flights"
>>>>>>> Stashed changes:3-semester-opgave-master/Frontpage/src/js/index.ts

var app = new Vue({
    el: "#app",
    data:{
        Bookings:[],
        Errors:[],
        currentTemp:'',
        wind:'',
        overcast:'',
        deleteId: 0,
        deleteMessage: "",
        formData: {flyNummer:"", destination:"",flytype:"", tid:0, mellemstop:"", selskab:"", vejr:"", Co2PerPassager:0, Co2PerKM:0},
        show: false
    },
    

    methods:{
        getAllBookings(){
            axios.get<Booking[]>(baseUri)
            .then((Response: AxiosResponse<Booking[]>)=>{
                this.Bookings= Response.data
                console.log(Response.data)
            })
            .catch((error:AxiosError) =>{
                console.log(error.message)
            })
        },
        deletebookings(deleteId: number){
            let uri: string = baseUri + "/" + deleteId
            axios.delete<void>(uri)
            .then((response: AxiosResponse)=>{
                this.deleteMessage = response.status + " " + response.statusText
                this.getAllBookings()
            })
            .catch((error:AxiosError) =>{
                console.log(error.message)
            })
        },
        addbookings(){
            axios.post<Booking>(baseUri, this.formData)
            .then((response: AxiosResponse) =>{
                let message: string = "response" + response.status + " " + response.statusText
                this.getAllBookings()
            })
            .catch((error:AxiosError) =>{
                console.log(error.message)
            })
        },
        selectedFlight(i: any){
<<<<<<< Updated upstream:Frontpage/src/js/index.ts
=======
            this.show = true;
>>>>>>> Stashed changes:3-semester-opgave-master/Frontpage/src/js/index.ts
            this.getWeather(i)
        },
         getWeather(i: any){
             console.log(this.Bookings[i].destination)
<<<<<<< Updated upstream:Frontpage/src/js/index.ts
             let uri: string = "api.openweathermap.org/data/2.5/weather?q=" + this.Bookings[i].destination + "&?units=metric&appid=08c6c9bc2e7946dc93f20fedbc40afd0"
             axios.get(uri)
             .then(Response => {
                 console.log(Response.data);
=======
             let uri: string = "http://api.openweathermap.org/data/2.5/weather?q=" + this.Bookings[i].destination + "&?units=metric&appid=08c6c9bc2e7946dc93f20fedbc40afd0"
             axios.get(uri)
             .then(Response => {
                 console.log(Response.data);
                 this.currentTemp= Response.data.main.temp - 272.15;
                 this.wind= Response.data.wind.speed + "m/s";
                 this.overcast= Response.data.weather[0].description;
                 console.log(this.currentTemp);
>>>>>>> Stashed changes:3-semester-opgave-master/Frontpage/src/js/index.ts
             })
             .catch(Error => {
                 console.log(Error);
                 
             });
         }
    }
})
