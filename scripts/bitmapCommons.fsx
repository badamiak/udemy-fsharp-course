open System.Drawing
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