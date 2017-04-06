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
    // let endX = startX + Math.round (float(distance)*cos(round plotter.direction))
    // let endY = startY + Math.round (float(distance)*sin(round plotter.direction))
    BitmapCommons.naiveLine (startX,startY) (endX,endY) plotter.color plotter.bitmap

    {plotter with position = (endX, endY)}