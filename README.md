# Day 1

## Part 1
I have no clue how the first part passed as I noticed after I submitted it that there was a bug in the dial reset as it most of the time didn't reset it correctly due to a missing 1. Should have been 100 * 1 + rotationCorrection but was actual 100 * rotationCorrection so it was 0 most of the time. But after adding that I now don't solve part one so I guess it was right somehow? I really don't understand math 😖.

### Part 2
So after a day at work and some food I realized that math is not for me so I bruteforced this one. I also spent some time cleaning up some logic like the wraping of the numbers. I think if I had just used brute force from the start on one I could have done both during my lunch break but c'est la vie.


# Day 2

## Part 1
I was a bit tierd when I started it but went smooth the only thing is that since the numbers got so large my prepared class that returns an int could not return the correct value as it needed to be a long and you can't cast it right. Reworked it to return a string just to avoid this issue in the futuer.

## Part 2