open System.Drawing
open System.IO

let sizemult = 50
let dim_x = 5
let dim_y = 5

let bitmap = new Bitmap(dim_x*sizemult,dim_y*sizemult)
let path = __SOURCE_DIRECTORY__

let setPixelsBlock x y color =
    let bx = x*sizemult
    let by = y*sizemult
    for dx in [0..sizemult-1] do
        for dy in [0..sizemult-1] do
            bitmap.SetPixel(bx+dx,by+dy,color)

let fill (bitmap: Bitmap) (color: Color) =
    for x in [0..bitmap.Width-1] do
        for y in [0..bitmap.Height-1] do
            bitmap.SetPixel(x,y,color)

fill bitmap Color.Black

setPixelsBlock 1 0 Color.Yellow
setPixelsBlock 3 0 Color.Yellow
setPixelsBlock 2 2 Color.Yellow
setPixelsBlock 0 3 Color.Yellow
setPixelsBlock 4 3 Color.Yellow
setPixelsBlock 1 4 Color.Yellow
setPixelsBlock 2 4 Color.Yellow
setPixelsBlock 3 4 Color.Yellow

// bitmap.RotateFlip(RotateFlipType.Rotate90FlipNone)


bitmap.Save(Path.Combine(path,"output","l15-bitmap.png"))

printfn "DONE"