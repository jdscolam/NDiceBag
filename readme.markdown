NDiceBag
--

A fluent dice library, you know, for games!

Using NDiceBag
--

1. Reference `NDiceBag.dll`
1. Add `using NDiceBag;` to your class
1. Grab some dice!

Grab Some Dice!
--

1. 3d6 would be `3.d()`
1. 3d4 would be `3.d(4)` 
1. 3d4x10 would be `3.d(4).x(10)`
1. 3d4+5 would be `3.d(4).Plus(5)`
1. 3d4-2 would be `3.d(4).Minus(2)`
1. 3d4 + 2d8 would be `3.d(4) + 2.d(8)`
1. 3d4 - 2d12 would be `3.d(4) - 2.d(12)`
1. 3d4 * 1d20 would be `3.d(4) * 1.d(20)`
1. 3d4d10 would be `3.d(4).d(10)`

Roll Some Dice
--

1. All dice object instances contain `.Roll()`
1. Operators return a dice object: `(3.d(4) + 1.d()).Roll()`
1. Modifiers are chain-able: `3.d().x(10).Plus(2).Minus(5).Roll()`
1. Operators are chain-able: `(3.d(8) + 2.d(4) - 3.d(6)).Roll()`

Coming Soon
--

1. Easy Percentile Dice
1. String parsing
1. Division?
1. More cool stuff

Credit Where it is Due
--

Mersenne Twister algorithm courtesy of Rory Plaire (codekaizen@gmail.com), Copyright 2007 - 2008