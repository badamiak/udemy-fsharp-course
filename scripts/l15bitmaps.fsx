open System.Drawing
open System.IO
#load "bitmapCommons.fsx"
let sizemult = 50
let dimensionX = 5
let dimensionY = 5

let bitmap = new Bitmap(dimensionX*sizemult,dimensionY*sizemult)
let path = __SOURCE_DIRECTORY__


let start () = 
    BitmapCommons.fill bitmap Color.Black

    BitmapCommons.setPixelsBlock bitmap 1 0 sizemult Color.Yellow
    BitmapCommons.setPixelsBlock bitmap 3 0 sizemult Color.Yellow
    BitmapCommons.setPixelsBlock bitmap 2 2 sizemult Color.Yellow
    BitmapCommons.setPixelsBlock bitmap 0 3 sizemult Color.Yellow
    BitmapCommons.setPixelsBlock bitmap 4 3 sizemult Color.Yellow
    BitmapCommons.setPixelsBlock bitmap 1 4 sizemult Color.Yellow
    BitmapCommons.setPixelsBlock bitmap 2 4 sizemult Color.Yellow
    BitmapCommons.setPixelsBlock bitmap 3 4 sizemult Color.Yellow

    bitmap.Save(Path.Combine(path,"output","l15-bitmap.png"))

    printfn "DONE"

start