#load "plotting.fsx"
open System.Drawing
open System.IO

let path = Path.Combine(__SOURCE_DIRECTORY__, "output", "l28-finalspirograph.png")

let initialPlotter : Plotting.Plotter =
    {
        position = (1000,1000)
        direction = 0.0
        color = Color.White
        bitmap = new Bitmap(2000, 2000)
    }

let cmdsStripe = 
    [
        Plotting.changeColor Color.LightYellow
        Plotting.move 45
        Plotting.turn 45.0
        Plotting.move 100
        Plotting.quasiCircle 5.0 45 45
        Plotting.changeColor Color.Red
        Plotting.turn 90.0
        Plotting.move 45
        Plotting.quasiCircle 15.0 45 45
        Plotting.turn 45.0
        Plotting.move 145
        Plotting.turn 180.0
        Plotting.move 50
        Plotting.changeColor Color.White
        Plotting.quasiCircle 5.0 50 50
        Plotting.moveTo (1000,1000)
    ]

initialPlotter
|> Plotting.fill Color.Black
|> Plotting.generateSpirograph cmdsStripe 180
|> Plotting.save path

