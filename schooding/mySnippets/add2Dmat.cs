//add 2D mat 
//! no checks
static int[,] add(int[,] mat1, int[,] mat2){
    int[,] res = new int[mat1.GetLength(0),mat1.GetLength(1)];
    for(int i =0;i<mat1.GetLength(0);i++){
        for(int j=0;j<mat1.GetLength(1);j++){
            res[i,j] = mat1[i,j]+mat2[i,j];
        }
    }
    return res;
}