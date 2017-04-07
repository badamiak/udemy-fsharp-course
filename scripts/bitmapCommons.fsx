open System.Drawing
open System


let setPixelsBlock (bitmap:Bitmap) x y sizeMultiplier color =
    let bx = x*sizeMultiplier
    let by = y*sizeMultiplier
    for dx in [0..sizeMultiplier-1] do
        for dy in [0..sizeMultiplier-1] do
            bitmap.SetPixel(bx+dx,by+dy,color)

let fill (bitmap: Bitmap) (color: Color) =
    for x in [0..bitmap.Width-1] do
        for y in [0..bitmap.Height-1] do
            bitmap.SetPixel(x,y,color)

let rec naiveLine (x0,y0) (x1,y1) (color:Color) (bitmap:Bitmap) =
    let draw () =
        let xLen = float (x1-x0)
        let yLen = float (y1-y0)

        printfn "from (%i,%i) to (%i,%i)" x0 y0 x1 y1

        let x0,y0,x1,y1 = if x0 > x1 then x1,y1, x0,y0 else x0,y0,x1,y1
        if xLen <> 0.0 then
            for x in x0..x1 do
                let proportion = float (x-x0) / xLen
                let y = (int (Math.Round (proportion * yLen))) + y0
                bitmap.SetPixel(x,y,color)
        
        let x0,y0,x1,y1 = if y0 > y1 then x1,y1,x0,y0 else x0,y0,x1,y1                
        if yLen <> 0.0 then
            for y in y0..y1 do
                let proportion = float (y-y0) / yLen
                let x = (int (Math.Round (proportion * xLen))) + x0
                bitmap.SetPixel(x,y,color)
    draw()

