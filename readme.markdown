NDiceBag
--

A fluent dice library, you know, for games!

Release Notes
--

**Version 1.1**
- Added `this.GrabPercentileDice()`
- Added `DivisionRoundingUp()` and `DivisionRoundingDown()`
- Added Basic Integer Operators (`+`, `-`, and `*`)
- Improved Tests (now test against 1000 rolls)

**Version 1.0**
- Initial Release

Using NDiceBag
--

1. Reference `NDiceBag.dll`
1. Add `using NDiceBag;` to your class
1. Grab some dice!

Grab Some Dice!
--

1. 3d6 would be `3.d()`
1. 3d4 would be `3.d(4)` 
1. 3d4x10 would be `3.d(4).x(10)` or `3.d(4) * 10`
1. 3d4+5 would be `3.d(4).Plus(5)` or `3.d(4) + 5`
1. 3d4-2 would be `3.d(4).Minus(2)` or `3.d(4) - 2`
1. 1d10 / 2 rounding up would be `1.d(10).DivideRoundingUp(2)`
1. 1d10 / 2 rounding down would be `1.d(10).DivideRoundingDown(2)`
1. 3d4 + 2d8 would be `3.d(4) + 2.d(8)`
1. 3d4 - 2d12 would be `3.d(4) - 2.d(12)`
1. 3d4 * 1d20 would be `3.d(4) * 1.d(20)`
1. 3d4d10 would be `3.d(4).d(10)`

Roll Some Dice
--

1. All dice object instances contain `.Roll()`
1. Operators return a dice object: `(3.d(4) + 1.d()).Roll()`
1. Modifiers are chain-able: `3.d().x(10).Plus(2).Minus(5).Roll()` or `(3.d() * 10 + 2 - 5).Roll()`
1. Operators are chain-able: `(3.d(8) + 2.d(4) - 3.d(6)).Roll()`

Input Needed (and Pull-Requests Accepted)
--

1. Thoughts on string parsing (Regular Expressions FTW/FTL?)
1. Possible ToString functionality (e.g. 3.d().ToString() == "3d6")
1. Thoughts on division operators (assume default rounding down?)

Coming Soon
--

1. String parsing
1. More cool stuff
1. ~~Easy Percentile Dice~~
1. ~~Division?~~



Credit Where it is Due
--

Mersenne Twister algorithm courtesy of Rory Plaire (codekaizen@gmail.com), Copyright 2007 - 2008