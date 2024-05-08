package today0507;
import java.util.Scanner;  // Scanner 클래스를 임포트합니다.
// scanner.close() 문제 다풀고 닫아줘야함 
public class Homework80p {
	 public static void main(String[] args) { 
	    Star.main(args);
	    System.out.println();
        SquareNumber.main(args);
	    System.out.println();
        CircleCircumference.main(args);
	    System.out.println();
	    Hms.main(args);
	    System.out.println();
	    lowercaseToUppercase.main(args);
	    System.out.println();
	    TemperatureConverter.main(args);
	    System.out.println();
	    CheckDivisibility.main(args);
	    System.out.println();
	    SumMultiples.main(args);
	    System.out.println();
	    CalculateAverage.main(args);
	 }
	 
	 
	 	
	 	// 문제 1
	 	public static class Star{
	 		public static void main(String[] args) {
	 			for (int i = 1; i < 7; i ++) {
	 			    for (int j = 6; j > i; j--) {
	 			        System.out.print(" ");
	 			    }
	 			    for (int j = 0; j < (i*2)-1; j++) {
	 			        System.out.print("*");
	 			    }
	 			   
	 			    System.out.println("");
	 			}
			}
	 	}
	  
	    // 문제 2
	    public static class SquareNumber {
	        public static void main(String[] args) {
	            Scanner scanner = new Scanner(System.in);  // Scanner 객체를 생성합니다.
	            System.out.print("제곱을 계산할 숫자를 입력하세요: ");  // 사용자에게 입력을 요청합니다.
	            int number = scanner.nextInt();  // 정수 입력을 받습니다.
	            int square = number * number;
	            System.out.println("숫자 " + number + "의 제곱은 " + square + "입니다.");
	        }
	    }
	    
	    // 문제 3
	    public static class CircleCircumference {
	        public static void main(String[] args) {
	        	Scanner scanner = new Scanner(System.in);  
	            System.out.print("뭔기둥의 밑면 반지름을 입력하세요: ");  
	            double radius = scanner.nextDouble();  
	            System.out.print("원기둥의 높이를 입력하세요: ");  
	            double radiusH = scanner.nextDouble();  
	            double a = Math.PI * (radius * radius);
	            double b = a * radiusH;
	            System.out.println("원기둥의 부피는 " + b);
	            
	        }
	    }
	    
	    // 문제 4
	    public static class Hms {
	    	public static void main(String[] args) {
	        	Scanner scanner = new Scanner(System.in);  
	    		System.out.print("초 단위 정수 입력하세요 :");
	            int sec = scanner.nextInt();
	            int min = sec / 60;
	            int hour = min / 60;
	            min = min % 60;
	            sec = sec % 60;
	            System.out.printf("-> %d시간 %d분 %d초%n", hour, min, sec);
	    	}
	    }
	    
	    // 문제 5
	    public static class lowercaseToUppercase {
	    	public static void main(String[] args) {
	    		char c = 'c'; // 소문자 c
	            int asciiDifference = 'a' - 'A'; // 소문자와 대문자 사이의 ASCII 차이 계산 (32)
	            char uppercase = (char)(c - asciiDifference); // c의 ASCII 값을 대문자로 변환
	            System.out.println(uppercase); // 변환된 대문자 C 출력
			}
	    }
	    
	    // 문제 6
	 	public static class TemperatureConverter {
	 	 	public static void main(String[] args) {
	 	 		Scanner scanner = new Scanner(System.in);
	 	 		System.out.print("화씨온도를 입력해주세요 :  ");
	 	 		double fahrenheit = scanner.nextDouble();  // 화씨 온도 예시
	 	 	    double celsius = (5.0 / 9) * (fahrenheit - 32);
	 	 	    System.out.printf("화씨 %.1f도는 섭씨로 %.2f도입니다.", fahrenheit, celsius);

	 	 	}
	 	 }
	 	 	    
	 	// isDivisibleOr 메소드 정의
	    public static boolean isDivisibleOr(int number) {
	        return number % 4 == 0 || number % 5 == 0;  // 4로 나누어 떨어지는지 확인
	    }
	    // isDivisibleAnd 메소드 정의
	    public static boolean isDivisibleAnd(int number) {
	    	return number % 4 == 0 && number % 5 == 0;  // 4로 나누어 떨어지는지 확인
	    }
	    // isDivisible4 메소드 정의
	    public static boolean isDivisible4(int number) {
	    	return number % 4 == 0;  // 4로 나누어 떨어지는지 확인
	    }
	    // isDivisible5 메소드 정의
	    public static boolean isDivisible5(int number) {
	    	return number % 5 == 0;  // 4로 나누어 떨어지는지 확인
	    }
	 
	 	// 문제 7
	 	public static class CheckDivisibility {
	 		public static void main(String[] args) {
	 			Scanner scanner = new Scanner(System.in);  // Scanner 객체를 생성합니다.
	            System.out.print("정수를 입력하세요 : ");
	 			int number = scanner.nextInt();  // 예시 숫자
	 	        boolean isDivisibleOr = isDivisibleOr(number);
	 	        boolean isDivisibleAnd = isDivisibleAnd(number);
	 	        boolean isDivisible4 = isDivisible4(number);
	 	        boolean isDivisible5 = isDivisible5(number);
	 	        System.out.println("정수" + number + "가 4로 또는 5로 나누어지면 "+ number + " % 4 == 0 || " + number + " % 5 == 0 이 " + isDivisibleOr + "이다");
	 	        System.out.println("정수" + number + "가 4로 또는 5로 나누어지면 "+ number + " % 4 == 0 && " + number + " % 5 == 0 이 " + isDivisibleAnd + "이다");
	 	        System.out.println("정수" + number + "가 4로 나누어지면 "+ number + " % 4 == 0이 " + isDivisible4 + "이다");
	 	        System.out.println("정수" + number + "가 5로 나누어지면 "+ number + " % 5 == 0이 " + isDivisible5 + "이다");
	            
	 		}
	 	}
		 
	 	// 문제 8 
	    public static class SumMultiples {
	    	 public static void main(String[] args) {
	    	        Scanner scanner = new Scanner(System.in);  // Scanner 객체를 생성합니다.
	    	        System.out.print("0~999 사이의 숫자를 입력하세요: ");
	    	        int number = scanner.nextInt();  // 정수로 입력받습니다.

	    	        if (number < 0 || number > 999) {
	    	            System.out.println("입력 값이 범위를 벗어났습니다.");
	    	        } else {
	    	            int sum = sumOfDigits(number);
	    	            System.out.println("입력한 숫자의 각 자리수의 합은: " + sum);
	    	        }
	    	          
	    	    }

	    	    // 각 자리수의 합을 계산하는 메소드
	    	    public static int sumOfDigits(int number) {
	    	        int sum = 0;
	    	        while (number > 0) {
	    	            sum += number % 10;  // 현재 자리의 숫자를 더합니다.
	    	            number /= 10;  // 다음 자리로 넘어갑니다.
	    	        }
	    	        return sum;
	    	    }
	    	    
	    }
		// 문제 9
		 public static class CalculateAverage {
			 public static void main(String[] args) {
				 Scanner scanner = new Scanner(System.in);
				 System.out.print("전공 이수 학점: ");  // 사용자에게 입력을 요청합니다.
		         int a = scanner.nextInt();  // 정수 입력을 받습니다.
		         System.out.print("교양 이수 학점 : ");  // 사용자에게 입력을 요청합니다.
		         int b = scanner.nextInt();  // 정수 입력을 받습니다.
		         System.out.print("일반 이수 학점 : ");  // 사용자에게 입력을 요청합니다.
		         int c = scanner.nextInt();  // 정수 입력을 받습니다.
		         
		         int number = a + b + c;
		         if ((number >= 140 && a >= 70) && (b >= 30 || c >= 30) || b + c == 80 ) {
		        	System.out.println("졸업가능"); 
		         }else {
		        	 System.out.println("졸업불가능");
		         }
		         scanner.close();
			}
		 }
}
