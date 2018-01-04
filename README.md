# kdbush
C# KD-Bush implementation 

[![Build status](https://ci.appveyor.com/api/projects/status/oq062xmnd8p955p1?svg=true)](https://ci.appveyor.com/project/marchello2000/kdbush)

Based on [this](https://github.com/mourner/kdbush) JavaScript implementation by [Vladimir Agafonkin](http://agafonkin.com/)

KD-Bush is a very fast static spatial index for 2D points based on a flat KD-tree.  
Compared to RBush:

* points only — no rectangles
* static — you can't add/remove items
* indexing is 5-8 times faster

## Usage
```cs
using KDBush

KDBush<int> kdbush = new KDBush<int>();

List<Point<int>> points = new List<Point<int>>(){
    new Point<int>(54, 1, 0),
    new Point<int>(97, 21, 1)
};

kdbush.Index(points);

// Get all points that lie inside the rectangle 
// (20, 30)-(50, 70)
var result = kdbush.Query(20, 30, 50, 70);

// Get all points that lie inside the circle 
// centered at (50, 50) with radius 20
result = kdbush.Query(50, 50, 20);
```