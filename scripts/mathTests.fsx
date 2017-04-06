#load "math.fsx"
#load "fstest.fsx"

Fstest.test "floor 2.6 should be 2" (fun () -> Math.floor 2.6) 2
Fstest.test "floor 2.4 should be 2" (fun () -> Math.floor 2.6) 2

Fstest.test "ceil  2.0 should be 2" (fun () -> Math.ceil 2.0) 2
Fstest.test "ceil  2.9 should be 3" (fun () -> Math.ceil 2.9) 3

Fstest.test "round 2.0 should be 2" (fun () -> Math.round 2.0) 2
Fstest.test "round 2.1 should be 2" (fun () -> Math.round 2.1) 2
Fstest.test "round 2.4 should be 2" (fun () -> Math.round 2.4) 2
Fstest.test "round 2.5 should be 3" (fun () -> Math.round 2.5) 3
Fstest.test "round 2.9 should be 3" (fun () -> Math.round 2.6) 3

Fstest.test "abs   2.0 should be 2.0" (fun () -> Math.abs 2.0) 2.0
Fstest.test "abs   -2.0 should be 2.0" (fun () -> Math.abs -2.0) 2.0
Fstest.test "abs   0.0 should be 0.0" (fun () -> Math.abs 0.0) 0.0

Fstest.summary()