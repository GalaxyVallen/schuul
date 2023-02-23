package solveit2;

public class StringType {
	public static void main(String[] args) {
		//Solve 1
//		String myString1; 
//		myString1 = "Nama";
		String myString1 = "nama" + "saya";
		String myString2 = "adalah"; 
		String myString3 = new String("abc");
		
		System.out.println(myString1.compareTo(myString2));
		System.out.println(myString2.equals(myString3));
		System.out.println(myString3 == myString1);
		
		System.out.println("=====================");
		
		//Solve 2
		String s1 = "ABC";
		String s2 = new String("DEF");
		String s3 = "AB" + "C";
		//Statement
		System.out.println(s1.compareTo(s2));//-3
		System.out.println(s2.equals(s3));
		System.out.println(s3 == s1);
		System.out.println(s2.compareTo(s3));//3
		System.out.println(s3.equals(s1));
		
		System.out.println("=====================");
		
		//Solve3
		String namaDepan = "Gusesa";
		String namaBelakang = "Ghifar";
		String namaLengkap ="Nama Sy: " + namaDepan + " " + namaBelakang;
		
		System.out.println( namaLengkap );
		System.out.print("Nama Sy: " + namaDepan +" "+ namaBelakang);
	}
}
