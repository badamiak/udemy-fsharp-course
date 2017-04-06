open System.Drawing
open System.IO
open System
#load "bitmapCommons.fsx"

printfn "%s" (DateTime.Now.ToString())
let pathAndFileName = 
    Path.Combine(__SOURCE_DIRECTORY__, "output","l20-backwardsLine.png")

let rec naiveLine (x0,y0) (x1,y1) (color:Color) (bitmap:Bitmap) =
    let draw () =
        let xLen = float (x1-x0)
        let yLen = float (y1-y0)

        let x0,y0,x1,y1 = if x0 > x1 then x1,y1, x0,y0 else x0,y0,x1,y1
        if xLen <> 0.0 then
            for x in x0..x1 do
                let proportion = float (x-x0) / xLen
                let y = (int (round (proportion * yLen))) + y0
                bitmap.SetPixel(x,y,color)
        
        let x0,y0,x1,y1 = if y0 > y1 then x1,y1,x0,y0 else x0,y0,x1,y1                
        if yLen <> 0.0 then
            for y in y0..y1 do
                let proportion = float (y-y0) / yLen
                let x = (int (round (proportion * xLen))) + x0
                bitmap.SetPixel(x,y,color)
    draw()


let bitmap = new Bitmap(256,256)

let envelope() =
    naiveLine (10,150) (110, 150) Color.Yellow bitmap
    naiveLine (110,150) (110, 200) Color.Yellow bitmap
    naiveLine (110,200) (10, 200) Color.Yellow bitmap
    naiveLine (10,200) (10, 150) Color.Yellow bitmap
    naiveLine (10,150) (60, 180) Color.Yellow bitmap
    naiveLine (60,180) (110, 150) Color.Yellow bitmap

let start() =
    BitmapCommons.fill bitmap Color.Black
    naiveLine (10,50) (50,50) Color.White bitmap
    naiveLine (50,50) (50,90) Color.White bitmap
    naiveLine (50,90) (10,90) Color.Red bitmap
    naiveLine (10,90) (10,50) Color.Red bitmap

    naiveLine (100,100) (150,150) Color.White bitmap
    naiveLine (150,100) (100,150) Color.Red bitmap

    naiveLine (150,150) (200,200) Color.White bitmap
    naiveLine (150,200) (200,150) Color.Red bitmap

    envelope()
    
    bitmap.Save(pathAndFileName)

start()
printfn "DONE"