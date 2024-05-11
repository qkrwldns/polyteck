## 80페이지

### **01번 문제: 별 찍기**

주어진 패턴대로 별을 찍는 공식:

```
mdCopy code
for (int i = 1; i < 7; i++) {
    for (int j = 6; j > i; j--) {
        System.out.print(" ");
    }
    for (int j = 0; j < (i * 2) - 1; j++) {
        System.out.print("*");
    }
    System.out.println();
}

```

### **02번 문제: 제곱 계산**

주어진 수의 제곱을 구하는 공식:

```
mdCopy code
result = number * number

```

### **03번 문제: 원기둥의 부피 계산**

원기둥의 부피를 구하는 공식:

```
mdCopy code
부피 = Math.PI * (radius * radius) * height

```

### **04번 문제: 초를 시, 분, 초로 변환**

초를 시간, 분, 초로 변환하는 공식:

```
mdCopy code
시간 = totalSeconds / 3600
분 = (totalSeconds % 3600) / 60
초 = totalSeconds % 60

```

### **05번 문제: 소문자를 대문자로 변환**

소문자를 대문자로 변환하는 공식:

```
mdCopy code
대문자 = (char) (소문자 - ('a' - 'A'))

```

### **06번 문제: 화씨를 섭씨로 변환**

화씨를 섭씨로 변환하는 공식:

```
mdCopy code
섭씨 = (5.0 / 9) * (화씨 - 32)

```

### **07번 문제: 나누어 떨어지는지 확인**

정수가 4 또는 5로 나누어 떨어지는지 확인하는 공식:

```
mdCopy code
4 또는 5로 나누어 떨어짐 = (number % 4 == 0) || (number % 5 == 0)

```

4와 5로 동시에 나누어 떨어지는지 확인하는 공식:

```
mdCopy code
4와 5로 나누어 떨어짐 = (number % 4 == 0) && (number % 5 == 0)

```

4로 나누어 떨어지는지 확인하는 공식:

```
mdCopy code
4로 나누어 떨어짐 = number % 4 == 0

```

5로 나누어 떨어지는지 확인하는 공식:

```
mdCopy code
5로 나누어 떨어짐 = number % 5 == 0

```

### **08번 문제: 숫자의 각 자리수의 합**

0에서 999 사이의 숫자의 각 자리수의 합을 구하는 공식:

```
mdCopy code
while (number > 0) {
    sum += number % 10;
    number /= 10;
}

```

### **09번 문제: 졸업 가능 여부 판단**

졸업 가능 여부를 판단하는 공식:

```
mdCopy code
if ((전공 이수 학점 >= 70 && 교양 이수 학점 >= 30 || 일반 이수 학점 >= 30) && (전공 + 교양 + 일반 >= 140) || (교양 + 일반 == 80)) {
    졸업 가능
} else {
    졸업 불가능
}

```

## 122페이지
https://fresher-developmentlog.tistory.com/98  


### **01번 문제: 성년 판별하기**

입력 받은 나이가 성년인지 미성년인지 판별하는 공식:

```
mdCopy code
if (age >= 19) {
    성년
} else {
    미성년
}

```

### **02번 문제: 등수에 따른 평가 출력하기**

입력 받은 등수에 따라 다른 메시지 출력하는 공식:

```
mdCopy code
switch (rank) {
    case 1:
        아주 잘했습니다.
        break;
    case 2, 3:
        잘했습니다.
        break;
    case 4, 5, 6:
        보통입니다.
        break;
    default:
        노력해야겠습니다.
}

```

### **03번 문제: 양의 정수 중 짝수의 합 구하기**

입력한 양의 정수 중 짝수만 합하는 공식:

```
mdCopy code
sum = 0
do {
    입력
    if (num % 2 == 0) {
        sum += num
    }
} while (num > 0)

```

### **04번 문제: 별 찍기 (오른쪽 정렬 삼각형)**

입력한 행 수만큼 별을 오른쪽 정렬하여 찍는 공식:

```
mdCopy code
for (int i = 1; i < 7; i++) {
    for (int j = 1; j < i; j++) {
        별 출력
    }
    줄바꿈
}

```

### **05번 문제: 피타고라스 수 찾기**

1부터 19까지의 수 중에서 피타고라스 방정식 𝑎2+𝑏2=𝑐2*a*2+*b*2=*c*2을 만족하는 모든 (a, b, c) 쌍을 찾는 공식:

```
mdCopy code
for (a = 1; a < 20; a++) {
    for (b = 1; b < 20; b++) {
        for (c = 1; c < 20; c++) {
            if (a * a + b * b == c * c) {
                (a, b, c) 출력
            }
        }
    }
}

```

### **06번 문제: 가위바위보 게임 (철수와 영희)**

철수와 영희의 가위바위보 승패를 결정하는 공식:

```
mdCopy code
if (철수의 선택 == 영희의 선택) {
    무승부
} else {
    각 선택에 따른 승패 결정
}

```

### **07번 문제: 가위바위보 게임 (이름을 변수로)**

주어진 이름의 사용자들이 가위바위보에서 누가 이겼는지 판별하는 공식:

```
mdCopy code
if (철수의 선택 == 영희의 선택) {
    무승부
} else {
    각 선택에 따른 승패 결정
}

```

### **08번 문제: 팩토리얼 계산**

정수 n의 팩토리얼을 계산하는 공식:

```
mdCopy code
if (n == 0 || n == 1) {
    return 1
} else {
    return n * factorial(n - 1)
}

```

### **09번 문제: 다중 메소드 오버로딩**

오버로딩된 **`foo`** 메소드를 활용하여 다양한 출력을 생성하는 공식:

```
mdCopy code
foo(String a) {
    a 출력
}

foo(String a, int i) {
    a i 출력
}

foo(String a, int i, int j) {
    a i j 출력
}

```

### **10번 문제: 소수 판별**

주어진 수가 소수인지 아닌지 판별하는 공식:

```
mdCopy code
if (n > 1) {
    for (i = 2; i < n; i++) {
        if (n % i == 0) {
            소수 아님
        }
    }
    소수
} else {
    소수 아님
}

```
