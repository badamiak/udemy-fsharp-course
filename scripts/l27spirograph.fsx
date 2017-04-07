open System.Drawing
open System.IO
#load "plotting.fsx"

let path = Path.Combine(__SOURCE_DIRECTORY__, "output", "l27-spirograph.png")
let initialPlotter : Plotting.Plotter = Plotting.fill Color.Black {
    position = (200,200)
    direction = 90.0
    color = Color.White
    bitmap = new Bitmap(400,400)
    }

let cmdsStripe = [Plotting.move 15; Plotting.turn 15.0; Plotting.polygon 3 10 ]

let cmdGen = seq { while true do yield! cmdsStripe}

let imageCommands = cmdGen |> Seq.take 75

let image () =
    imageCommands
    |> Seq.fold (fun plot cmds -> plot |> cmds ) initialPlotter
    |> Plotting.save path

image()

// Plotting.polygon 3 60 initialPlotter |> Plotting.save path

// let fizzy = 
//     seq {
//         for x in 1..100 ->
//             if x % 3 = 0 && x % 5 = 0 then
//                 "FizzBuzz"
//             elif x%3=0 then
//                 "Fizz"
//             elif x%5=0 then
//                 "Buzz"
//             else
//                 x.ToString()
//     }

// for i in fizzy do
//     printfn "%A" i