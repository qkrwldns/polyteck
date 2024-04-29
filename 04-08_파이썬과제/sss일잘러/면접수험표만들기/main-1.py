# 필요한 라이브러리를 가져옵니다
from faker import Faker  # 가짜 데이터 생성을 위한 Faker 라이브러리
import pandas as pd  # 데이터프레임을 다루기 위한 Pandas 라이브러리
import os  # 파일 경로 조작을 위한 os 라이브러리

# 현재 스크립트가 있는 디렉토리로 작업 디렉토리를 변경합니다
os.chdir(os.path.dirname(os.path.abspath(__file__)))

# Faker 객체를 생성합니다. 한국어로 랜덤 데이터를 생성합니다.
fake = Faker("ko_KR")

# 가짜 이름을 생성하여 리스트에 저장합니다. 10개의 이름을 생성합니다.
가짜이름_list = [fake.name() for i in range(10)]

# 수험번호를 생성하여 리스트에 저장합니다. "2022-"로 시작하고 1부터 10까지의 수험번호를 생성합니다.
수험번호_list = ["2022-" + str(i + 1).zfill(3) for i in range(10)]

# 생성된 데이터를 출력합니다.
print(가짜이름_list)
print(수험번호_list)

# 데이터프레임을 생성합니다. '이름' 열에는 가짜이름_list를, '수험번호' 열에는 수험번호_list를 넣습니다.
df = pd.DataFrame({'이름': 가짜이름_list,
                   '수험번호': 수험번호_list})

# 데이터프레임을 Excel 파일로 저장합니다.
df.to_excel('수험번호.xlsx')
