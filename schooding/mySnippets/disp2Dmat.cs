//disp a 2D mat
//? cleaner formating?

static void disp(int[,]mat1){
    for(int i =0;i<mat1.GetLength(0);i++){
        for(int j=0;j<mat1.GetLength(1);j++){
            Console.Write(mat1[i,j]);
        }
        Console.WriteLine();
    }
}