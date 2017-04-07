open System.Drawing
open System.IO
open System

#load "bitmapCommons.fsx"
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
    let newDir = plotter.direction + amt
    let angled = {plotter with direction = newDir}
    angled

let move dist (plotter: Plotter) =
    let curPos = plotter.position
    let angle = plotter.direction
    let startX = fst curPos
    let startY = snd curPos
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
    let angle = Math.Round(360.0 / float sides)
    printfn "polygon angle %A" angle
    Seq.fold (fun s i -> turn angle (move length s)) plotter [1.0..(float sides)]

let save (path:string) (plotter: Plotter) =
    plotter.bitmap.Save(path)