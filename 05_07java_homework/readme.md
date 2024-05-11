## 80페이지

### 02번 문제

주어진 수의 제곱을 구하는 공식:
```md
result = number * number
```

```java
public class SquareNumber {
    public static void main(String[] args) {
        int number = 7;  // 예시 숫자
        int square = number * number;
        System.out.println("숫자 " + number + "의 제곱은 " + square + "입니다.");
    }
}
```

### 03번 문제
원의 둘레를 구하는 공식(반지름을 이용):

```md
circumference = 2 * π * radius
```
```java
public class CircleCircumference {
    public static void main(String[] args) {
        double radius = 10;  // 반지름 예시
        double circumference = 2 * Math.PI * radius;
        System.out.println("반지름이 " + radius + "인 원의 둘레는 " + circumference + "입니다.");
    }
}
```
여기도 다시 고쳐야함

### 04번 문제

초를 시, 분, 초로 변환하는 공식:

```md
hours = totalSeconds / 3600
minutes = (totalSeconds % 3600) / 60
seconds = totalSeconds % 60
```
```java
 int min=0,hour=0,sec,time=0;
        Scanner sc =new Scanner(System.in);
        System.out.print("초 입력 :");
        sec=sc.nextInt();
        
        min=sec/60;
        hour=min/60;
        min=min%60;
        sec=sec%60;
        System.out.printf("-> %d시간 %d분 %d초 ",hour,min,sec)
```

### 05번 문제
문자를 ASCII 코드로 변환하는 공식:
```md
asciiValue = (int) character
```
```java
public class CharToAscii {
    public static void main(String[] args) {
        char character = 'A';  // 문자 예시
        int asciiValue = (int) character;
        System.out.println("문자 '" + character + "'의 ASCII 코드 값은 " + asciiValue + "입니다.");
    }
}
```
여기 다시 코쳐야함 대문자로 바꾸는거였음 

### 06번 문제

 화씨 온도(F)를 섭씨 온도(C)로 변환하는 것. 공식:  C = (5/9) * (F - 32)
 
```java
public class TemperatureConverter {
    public static void main(String[] args) {
        double fahrenheit = 100;  // 화씨 온도 예시
        double celsius = (5.0 / 9) * (fahrenheit - 32);
        System.out.println("화씨 " + fahrenheit + "도는 섭씨로 " + celsius + "도입니다.");
    }
}
```

### 07번 문제
수를 입력받아 나누어 떨어지는지 확인하는 코드. 4로 나누어 떨어지면 true, 그렇지 않으면 false를 반환. 공식 :  number%4 == 0

```java
public class CheckDivisibility {
    public static void main(String[] args) {
        int number = 64;  // 예시 숫자
        boolean isDivisible = (number % 4 == 0);
        System.out.println("숫자 " + number + "는 4로 나누어 떨어지나요? " + isDivisible);
    }
}
```

### 08번 문제
공식: 999 이하의 자연수 중 3 또는 5의 배수의 합을 구하는 로직. 
i % 3 == 0 || i % 5 == 0
  
```java
public class SumMultiples {
    public static void main(String[] args) {
        int sum = 0;
        for (int i = 1; i < 1000; i++) {
            if (i % 3 == 0 || i % 5 == 0) {
                sum += i;
            }
        }
        System.out.println("999 아래의 모든 자연수 중 3 또는 5의 배수의 합은 " + sum + "입니다.");
    }
}
```

### 09번 문제
세 과목의 점수 평균을 내는 공식 : average = (korean + math + english) / 3

```java
public class CalculateAverage {
    public static void main(String[] args) {
        int korean = 75;
        int math = 70;
        int english = 10;  // 낮은 점수 예시
        double average = (korean + math + english) / 3.0;
        System.out.println("국어 점수: " + korean + ", 수학 점수: " + math + ", 영어 점수: " + english);
        System.out.println("평균 점수는 " + average + "입니다.");
    }
}
```

## 122페이지
https://fresher-developmentlog.tistory.com/98  
### 03번 문제
```java
public class SumEvenNumbers {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int sum = 0;
        int number;

        do {
            System.out.print("양의 정수를 입력하세요 (종료하려면 음수나 0을 입력): ");
            number = scanner.nextInt();

            // 입력받은 숫자가 양수이고 짝수인 경우에만 합산
            if (number > 0 && number % 2 == 0) {
                sum += number;
            }
        } while (number > 0); // 양수가 아니면 루프 종료

        System.out.println("입력된 양의 짝수들의 합은 " + sum + "입니다.");
        scanner.close();
    }
}
```
