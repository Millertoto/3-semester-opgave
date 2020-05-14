interface Person {
    firstName: string;
    lastName: string;
}


let user: Person = { firstName: "Jack", lastName: "Moe" };
let inputElement: HTMLInputElement = <HTMLInputElement>document.getElementById("wordInput");
let selectValue: HTMLSelectElement = <HTMLSelectElement>document.getElementById("textChange");
let output: HTMLElement = <HTMLElement> document.getElementById("content");
let showNameButton: HTMLButtonElement = <HTMLButtonElement>document.getElementById("showNameButton");
showNameButton.addEventListener("click", showWords);

function showWords(): void {
    let word: string = inputElement.value;
    let choice: string = selectValue.value;
    if (word.length > 0) {
        if (choice == "toUpper") {
            output.innerHTML = word.toUpperCase();    
        }
        if (choice == "toLower") {
            output.innerHTML = word.toLowerCase();
        }
        if (choice == "individualSpacing") {
            output.innerHTML = word.split("").join(" ");
        }
    }
    else{
        output.innerHTML = "empty"
    }
}
