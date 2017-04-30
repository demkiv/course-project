module DeanerySystem.ClientSide.Cabinet {
    export class ContactInfo {
        public FirstName: string;
        public LastName: string;
        public Age: number;
        public Adresses: Adress[];

        constructor() {
            this.FirstName = "John";
            this.LastName = "Connor";
            this.Age = 25;
            this.Adresses = [new Adress("Lviv", "Ukraine"), new Adress("NY", "USA")];
        }
    }
}