open System.Drawing
open System.IO
open System
#load "l15_bitmaps.fsx"

// open System.Math

printfn "%s" (DateTime.Now.ToString())
let pathAndFileName = 
    Path.Combine(__SOURCE_DIRECTORY__, "output","l17-naiveline.png")

let round (f:float) = //hack to provide round method since System.Math can't be found
    if f % 1.0 >= 0.5 then
        int f + 1
    else
        int f
let abs (x:float) =
    if x >= 0.0 then x else -x

let naiveLine (x0,y0) (x1,y1) (color:Color) (bitmap:Bitmap) =
    let xLen = float (x1-x0)
    let yLen = float (y1-y0)
    printfn "%f" xLen
    printfn "%f" yLen

    if xLen <> 0.0 then
        for x in x0..x1 do
            let proportion = float (x-x0) / xLen
            let y = (int (round (proportion * yLen))) + y0
            printfn "%i %f" y proportion
            bitmap.SetPixel(x,y,color)
    elif yLen <> 0.0 then
        for y in y0..y1 do
            let proportion = float (y-y0) / yLen
            let x = (int (round (proportion * xLen))) + x0
            printfn "%i %f" x proportion
            bitmap.SetPixel(x,y,color)


let bitmap = new Bitmap(256,256)


L15_bitmaps.fill bitmap Color.Black
naiveLine (10,50) (50,50) Color.White bitmap
naiveLine (50,50) (50,100) Color.White bitmap

bitmap.Save(pathAndFileName)

printfn "DONE"