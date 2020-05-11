import axios, {
    AxiosResponse,
    AxiosError
} from "../../node_modules/axios/index"

interface Booking {
    flytype: string;
    tid: number;
    mellemstop: string;
    selskab: string;
    vejr: string;
    Co2PerPassager: number;
    Co2PerKM: number;
    destination: string;
    flyNummer: number;
}


let baseUri: string = "http://jsonplaceholder.typicode.com/posts"

var app = new Vue({
    el: "#app",
    data:{
        Bookings:[],
        errors:[],
        deleteId: 0,
        deleteMessage: "",
        formData: {flyNummer:0, destination:"",flytype:"", tid:0, mellemstop:"", selskab:"", vejr:"", Co2PerPassager:0, Co2PerKM:0}
    },
    

    methods:{
        getAllBookings(){
            axios.get<Booking[]>(baseUri)
            .then((Response: AxiosResponse<Booking[]>)=>{
                this.Bookings= Response.data
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
        }
    }
})
