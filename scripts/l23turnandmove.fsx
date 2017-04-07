open System.Drawing
open System.IO
open System
#load "plotting.fsx"
#load "bitmapCommons.fsx"

let path = Path.Combine(__SOURCE_DIRECTORY__, "output", "l23-turnAndMove.png")

let turn amt (plotter: Plotting.Plotter) =
    let p = {plotter with direction = float(plotter.direction + amt) % 360.0}
    p

let move dist (plotter: Plotting.Plotter) =
    let curPos = plotter.position
    let angle = plotter.direction
    let startX, startY = curPos
    let rads = (angle - 90.0) * Math.PI/180.0
    let endX = (float startX) + float(dist) * cos rads
    let endY = (float startY) + float(dist) * sin rads
    let plotted = Plotting.naiveLine (int endX, int endY) plotter
    plotted


let plotter = {position = (5, 20); color = Color.White; direction = 0.0; bitmap = new Bitmap(100,30)}: Plotting.Plotter
BitmapCommons.fill plotter.bitmap Color.Black

let finished = move 15 plotter
            |> turn 90.0
            |> move 60
            |> turn 90.0
            |> move 20
            |> turn -90.0
            |> move 30
            |> turn -90.0
            |> move 15
            |> fun (p:Plotting.Plotter) -> p.bitmap.Save(path)