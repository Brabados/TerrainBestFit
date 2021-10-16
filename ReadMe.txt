This project is a recreated version of a terrain editor I built for unity.
The core concept is taking a square section of a heightmap and plotting the plane
of best fit(relative to the Z-axis) to make building placement on the uneven ground
look more natural and blend in with the surrounding terrain.
Most complexities came from finding a solution that didn't reduce the plane to be touching 0,0,0 
and to match with the surrounding topography. Basic implementation of this
would then only work on a semi-flat set of coordinates, not on the vastly different and 
sporadic levels of a heightmap.
