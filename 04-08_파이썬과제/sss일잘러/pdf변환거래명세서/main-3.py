import win32com.client
import os

excel = win32com.client.Dispatch("Excel.Application")

load_file_path = r"C:\Users\user123\Desktop\learn-py\basic\04-08\sss일잘러과제\pdf변환거래명세서\거래명세표_땡땡초등학교.xlsx"

wb = excel.Workbooks.Open(load_file_path)
ws_sheet = wb.ActiveSheet
ws_sheet.Select()

save_path = os.path.splitext(load_file_path)[0] + '.pdf'
wb.ActiveSheet.ExportAsFixedFormat(0, save_path)

wb.Close(False)
excel.Quit()
