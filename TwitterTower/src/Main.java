import java.util.Scanner;
public class Main {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int option=0,height,width;
        while(option!=3){
            System.out.println("Press 1 for a rectangular tower,2 for a triangle tower or 3 to exit");
            option=scanner.nextInt();
            System.out.println("Press the height and width of the tower");
            height=scanner.nextInt();
            width=scanner.nextInt();
            switch (option) {
                case 1:
                    if(width==height||Math.abs(height-width)>5)
                        System.out.println("The tower area is "+width*height);
                    else
                        System.out.println("The tower perimeter is "+ (width+height)*2);
                    break;
                case 2:
                    System.out.println("Press 1 to calculate the perimeter of the tower or 2 to print the tower");
                    int option2=scanner.nextInt();
                    if(option2==1)
                        System.out.println("The tower perimeter is "+(width+2* Math.sqrt(Math.pow(width/2, 2)+Math.pow(height, 2))));
                    else{
                        if(width%2==0||height*2<width)
                            System.out.println("It is not possible to print the tower");
                        else{

                            int numSpace=width/2,numBlocks,numLines,sherit=0,numStars;
                            for (int i = 1; i <=numSpace; i++) {
                                System.out.print(" ");
                            }
                            System.out.println("*");
                            if(width>3){
                                numSpace-=1;
                                numStars=3;
                                numBlocks=width/2-1;
                                numLines=(height-2)/numBlocks;
                                sherit=height%numBlocks;
                            }
                            else{   
                                numBlocks=1;
                                numLines=height-2;
                                numStars=1;
                            }
                            for (int i = 1; i <= numBlocks; i++) {
                                for (int j = 1; j <= numLines+sherit; j++) {
                                    for (int k = 0; k < numSpace; k++) {
                                        System.out.print(" ");
                                    }
                                    for (int k = 1; k <=numStars; k++) {
                                        System.out.print("*");
                                    }
                                    System.out.println("");
                                }
                                numSpace-=1;
                                numStars+=2;

                                sherit=0;
                            }
                            for (int i = 0; i <width; i++) {
                                System.out.print("*");
                            }
                            System.out.println("");
                        }
                    }
                    break;
                default:
                    System.out.println("Erorr, There is no such option");
                    break;
            }
        }
    }
    }
