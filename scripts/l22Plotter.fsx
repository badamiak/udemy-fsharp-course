open System.Drawing
open System.IO
open System

#load "bitmapCommons.fsx"
#load "math.fsx"
let path = Path.Combine(__SOURCE_DIRECTORY__, "output", "l22-plotter.png")

type Plotter = {
    position: int * int
    color: Color
    direction: float
    bitmap: Bitmap
}

let plotNaiveLine (endX, endY) (plotter: Plotter) =
    let startX, startY = plotter.position
    // let endX = startX + Math.round (float(distance)*cos(round plotter.direction))
    // let endY = startY + Math.round (float(distance)*sin(round plotter.direction))
    BitmapCommons.naiveLine (startX,startY) (endX,endY) plotter.color plotter.bitmap

    {plotter with position = (endX, endY)}

let turn amt (plotter: Plotter) =
    let p = {plotter with direction = plotter.direction + amt}
    p

let move dist (plotter: Plotter) =
    plotter

let start () =
    let plotter = {position = (0,0); color = Color.White; direction = 90.0; bitmap = new Bitmap(256,256)}
    BitmapCommons.fill plotter.bitmap Color.Black
    let temp = plotNaiveLine (255,255) plotter
    temp.bitmap.Save(path)
    temp

start()