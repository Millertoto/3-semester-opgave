import axios, {
    AxiosResponse,
    AxiosError
} from "../../node_modules/axios/index";

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

let baseuri: string = "http://anbo-bookstorerest.azurewebsites.net/api/books"

function bookingToString(booking: Booking): string{
    return booking.flyNummer + " " + booking.destination + " " + booking.flytype + " " + booking.tid + " " + booking.mellemstop + " " + booking.selskab + " " + booking.vejr + " " + booking.Co2PerPassager + " " + booking.Co2PerKM;
    }

let getAllButton: HTMLButtonElement = <HTMLButtonElement>document.getElementById("getAllButton");
getAllButton.addEventListener("click", showAllBooking);

let getByIdButton: HTMLButtonElement = <HTMLButtonElement>document.getElementById("getByIdButton");
getByIdButton.addEventListener("click", get);


    function bookingArrayToList (booking: Booking[]): string {
        if (booking.length == 0) {
            return "empty";
        }
        let result: string = "<ul class='list-group' id='bookinglist' >";
        booking.forEach((booking: Booking) => {
            result += "<li class='list-group-item'>" + bookingToString(booking) + "</li>";
        });
        result += "</ul>";
        return result;
    }

    function showAllBooking(): void {
        let outputElement: HTMLDivElement = <HTMLDivElement>document.getElementById("content");
        axios.get<Booking[]>(baseuri)
            .then(function (response: AxiosResponse<Booking[]>): void {
                // element.innerHTML = generateSuccessHTMLOutput(response);
                // outputHtmlElement.innerHTML = generateHtmlTable(response.data);
                // outputHtmlElement.innerHTML = JSON.stringify(response.data);
                let result: string = "<ul id='bookinglist'>";
                response.data.forEach((booking: Booking) => {
                    result += "<li>" + booking.flyNummer + " " + booking.destination + " " + booking.flytype + " " + booking.tid + " " + booking.mellemstop + " " + booking.selskab + " " + booking.vejr + " " + booking.Co2PerPassager + " " + booking.Co2PerKM; + "</li>";
                });
                result += "</ul>";
                outputElement.innerHTML = bookingArrayToList(response.data);
            })
            .catch(function (error: AxiosError): void { // error in GET or in generateSuccess?
                if (error.response) {
                    // the request was made and the server responded with a status code
                    // that falls out of the range of 2xx
                    // https://kapeli.com/cheat_sheets/Axios.docset/Contents/Resources/Documents/index
                    outputElement.innerHTML = error.message;
                } else { // something went wrong in the .then block?
                    outputElement.innerHTML = error.message;
                }
            });
        }

        function getByDestination(): void {
            console.log("getByDestination");
            let inputElement: HTMLInputElement = <HTMLInputElement>document.getElementById("deleteInput");
            let outputElement: HTMLDivElement = <HTMLDivElement>document.getElementById("contentDeleteOrGetById");
            let title: string = inputElement.value;
            let uri: string = baseuri + "/" + title;
            axios.get<Booking>(uri)
                .then((response: AxiosResponse) => {
                    if (response.status == 200) {
                        outputElement.innerHTML = response.status + " " + bookingToString(response.data);
                    } else {
                        outputElement.innerHTML = "No such destination: " + title;
                    }
                })
                .catch((error: AxiosError) => {
                    outputElement.innerHTML = error.code + " " + error.message
                })
        }