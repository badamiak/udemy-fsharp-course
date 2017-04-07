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

let naiveLine (endX, endY) (plotter: Plotter) =
    let startX, startY = plotter.position
    
    BitmapCommons.naiveLine (startX,startY) (endX,endY) plotter.color plotter.bitmap

    {plotter with position = (endX, endY)}

let turn amt (plotter: Plotter) =
    let p = {plotter with direction = float(plotter.direction + amt) % 360.0}
    p

let move dist (plotter: Plotter) =
    let curPos = plotter.position
    let angle = plotter.direction
    let startX, startY = curPos
    let rads = (angle - 90.0) * Math.PI/180.0
    let endX = (float startX) + float(dist) * cos rads
    let endY = (float startY) + float(dist) * sin rads
    let plotted = naiveLine (int endX, int endY) plotter
    plotted

let fill (color: Color) (plotter:Plotter) =
    for x in [0..plotter.bitmap.Width-1] do
        for y in [0..plotter.bitmap.Height-1] do
            plotter.bitmap.SetPixel(x,y,color)
    plotter

let polygon (sides: int) length plotter =
    let angle = round 360.0 / float sides
    Seq.fold (fun s i -> 
        move length s
        |> turn angle) plotter [1.0..float sides]

let save (path:string) (plotter: Plotter) =
    plotter.bitmap.Save(path)