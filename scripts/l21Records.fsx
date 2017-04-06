type Date = {
    day: int
    month: int
    year: int
}

type Person = {
    firstName: string
    lastName: string
    favClub: string
    age: int
    dateOfBirth: Date
}

let me = {
    firstName = " Mark"
    lastName = "Gray"
    favClub = "ManUtd"
    age = 24
    dateOfBirth = {day = 1;month = 2;year = 3}
}
printfn "%A" me

let temp = {me with age = 30; favClub="ArsenalLnd"}
printfn "%A" temp

let setBirthDay (person:Person) (dob:Date) =
    {person with dateOfBirth = dob}

let newOne = setBirthDay temp {day = 10; month = 12; year = 2015}
printfn "temp = %A" temp
printfn "newOne = %A" newOne