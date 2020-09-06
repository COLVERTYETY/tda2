// init a 2D mat from a h and val
// h: height of square mat
// val: filler of the square mat
static int[,] makemat(){
    int h = Convert.ToInt32(Console.ReadLine());
    int val = Convert.ToInt32(Console.ReadLine());
    int[,] mat = new int[h,h];
    for(int i =0;i<h;i++){
        for(int j = 0;j<h;j++){
            mat[i,j]=val;
        }
    }
    return mat;
}