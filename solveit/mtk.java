package solveit;
import java.util.Scanner;
public class mtk {

	public static void main(String[] args) {
		Scanner s = new Scanner(System.in);

	    System.out.println("Masukkan nilai alas segitiga: ");
	    double base = s.nextDouble();

	    System.out.println("Masukkan nilai tinggi segitiga: ");
	    double height = s.nextDouble();

	    double area = (double)1/2 * base * height;

	    System.out.println("Area segitiga adalah: " + area);
	}

}
