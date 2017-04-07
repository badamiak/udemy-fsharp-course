#load "plotting.fsx"
open System.Drawing
open System.IO

let path = Path.Combine(__SOURCE_DIRECTORY__,"output","l26-polygons.png")
let plotter : Plotting.Plotter = {
    position = (0,0)
    color = Color.White
    direction = 90.0
    bitmap = new Bitmap (256,256)
} 

let save (path:string) (plotter: Plotting.Plotter) =
    plotter.bitmap.Save(path)
let rectangle x y plotter=
    plotter
    |> Plotting.move x
    |> Plotting.turn 90.0
    |> Plotting.move y
    |> Plotting.turn 90.0
    |> Plotting.move x    
    |> Plotting.turn 90.0
    |> Plotting.move y
    


let polygon (sides: int) length plotter =
    let angle = round 360.0 / float sides
    Seq.fold (fun s i -> 
        Plotting.move length s
        |> Plotting.turn angle) plotter [1.0..float sides]

let triangle () : Plotting.Plotter = 
    plotter 
        |> polygon 3 20

plotter
    |> Plotting.fill Color.Black 
    |> rectangle 60 20
    |> fun p -> {p with position = (100,100)}
    |> polygon 3 50
    |> fun p -> {p with position = (150,150); direction = 0.0}
    |> polygon 8 20
    |> save path
