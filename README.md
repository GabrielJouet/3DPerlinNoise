# 3DPerlinNoise
A very basic 3D perlin noise generator. I was searching around to build a project on Unity and couldn't find one, so I made mine.  

## Usage
### Important - Float needs to be with a , and not a .

They are few parameters you can change while generating a new perlin noise:  
- Seed, for random purpose, needed in integer format.  
- Width of the matrix, x axis, needed in integer format.  
- Height of the matrix, y axis, needed in integer format.    
- Length of the matrix, needed in integer format.  
- Maximum value of a point, can be a float, usually 1,0.  
- Point likehood, higher values means more 1,0 points, lower means more empty spaces, can be a float.  
- Fall off, higher values means small values, can be a float.  

Once parameters are given, the generation starts, be aware that huge matrices (over 300 in any direction) will take time.  

Any feedback appricieted!