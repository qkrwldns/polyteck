package today0507;

import java.util.Scanner;

// scanner.close(); 다풀고 닫아주기
public class Homework122p {
	public static void main(String[] args) {
		// 문제 1
		checkAdult();
		System.out.println();
		// 문제 2
		rank();
		System.out.println();
		// 문제 3
		sumPositiveNumber();
		System.out.println();
		// 문제 4
		star();
		System.out.println();
		// 문제 5
		rightTriangle();
		System.out.println();
		// 문제 6
		rps1();
		System.out.println();
		// 문제 7
		String c = "철수";
		String y = "영희";
		whosWin(c, y);
		System.out.println();
		// 문제 8
		System.out.println(factorial(5));
		System.out.println();
		// 문제 9
		foo("안녕", 1);
		foo("안녕", 1, 2);
		foo("잘 있어");
		System.out.println();
		// 문제 10
		System.out.println();
		Scanner scanner = new Scanner(System.in);
		System.out.print("양의 정수를 입력하세요 : ");
		int num = scanner.nextInt();
		if (isPrime(num)) {
			System.out.println(num + "는 소수입니다.");
		} else {
			System.out.println(num + "는 소수가 아닙니다.");
		}
		System.out.println();

	}

	// 문제 1
	public static void checkAdult() {
		Scanner scanner = new Scanner(System.in);
		System.out.print("나이를 입력하세요 : ");
		int age = scanner.nextInt();
		if (age >= 19) {
			System.out.println("성년");
		} else {
			System.out.println("미성년");
		}

	}

	// 문제 2
	public static void rank() {
		Scanner scanner = new Scanner(System.in);
		System.out.print("등수를 입력하세요 1 ~ 6: ");
		int rank = scanner.nextInt();

		switch (rank) {
		case 1:
			System.out.println("아주 잘했습니다.");
			break;
		case 2:
		case 3:
			System.out.println("잘했습니다.");
			break;
		case 4:
		case 5:
		case 6:
			System.out.println("보통입니다.");
			break;
		default:
			System.out.println("노력해야겠습니다.");
		}
	}

	// 문제 3
	public static void sumPositiveNumber() {
		Scanner scanner = new Scanner(System.in);
		int num;
		int sum = 0;

		do {
			System.out.print("양의 정수를 입력하세요 :  ");
			num = scanner.nextInt();
			if (num % 2 == 0) {
				sum += num;
			}
		} while (num > 0);
		System.out.printf("입력한 양의 정수 중에서 짝수의 합은 %d\n", sum);

	}

	// 문제 4
	public static void star() {
		for (int i = 1; i < 7; i++) {
			for (int j = 1; j < i; j++) {
				System.out.print("*");
			}
			System.out.println();
		}
	}

	// 문제 5
	public static void rightTriangle() {
		for (int a = 1; a < 20; a++) {
			for (int b = 1; b < 20; b++) {
				for (int c = 1; c < 20; c++) {
					if (a * a + b * b == c * c) {
						System.out.printf("%d, %d, %d", a, b, c);
						System.out.println();
					}
				}
			}
		}
	}

	// 문제 6
	public static void rps1() {
		Scanner scanner = new Scanner(System.in);
		System.out.print("철수 : ");
		String su = scanner.next();
		System.out.print("영희 : ");
		String young = scanner.next();
		// == 을 쓰면 안됨 문자는 equals를 써야함
		if ((su.equals("r") && young.equals("s")) || (su.equals("p") && young.equals("r"))) {
			System.out.println("철수, 승!");
		} else if ((young.equals("r") && su.equals("s")) || (young.equals("p") && su.equals("r"))) {
			System.out.println("영희, 승!");
		} else if (su.equals("p") && young.equals("s")) {
			System.out.println("영희, 승!");
		} else if (young.equals("p") && su.equals("s")) {
			System.out.println("철수, 승!");
		} else if (su.equals(young)) {
			System.out.println("무승부");
		}
	}

	// 문제 7
	public static void whosWin(String c, String y) {
		Scanner scanner = new Scanner(System.in);
		System.out.print(c + " : ");
		String su = scanner.next();
		System.out.print(y + " : ");
		String young = scanner.next();
		// == 을 쓰면 안됨 문자는 equals를 써야함
		if ((su.equals("r") && young.equals("s")) || (su.equals("p") && young.equals("r"))) {
			System.out.println("철수, 승!");
		} else if ((young.equals("r") && su.equals("s")) || (young.equals("p") && su.equals("r"))) {
			System.out.println("영희, 승!");
		} else if (su.equals("p") && young.equals("s")) {
			System.out.println("영희, 승!");
		} else if (young.equals("p") && su.equals("s")) {
			System.out.println("철수, 승!");
		} else if (su.equals(young)) {
			System.out.println("무승부");
		}
		
	}

	// 문제 8
	public static int factorial(int n) {
		if (n == 0 || n == 1) {
			return 1;
		}

		return switch (n) {
		default -> n * factorial(n - 1);
		};
	}

	// 문제 9
	public static void foo(String a) {
		System.out.println(a);
	}

	public static void foo(String a, int i) {
		System.out.println(a + " " + i);
	}

	public static void foo(String a, int i, int j) {
		System.out.println(a + " " + i + " " + j);
	}

	// 문제 10
	public static boolean isPrime(int n) {
		boolean result = true;
		if (n > 1) {
			for (int i = 2; i < n; i++) {
				if (n % i == 0) {
					result = false;
				}
			}
			return result;
		}
		return result;
		
	}

}
