# CRESSI_GOA_Diving_Computer_PC_Interface_Formatter
CRESSI GOAからPCインタフェースで取得したダイビングログをCSVにする。Convert log file to CSV that the diving-computer CRESSI GOA's PC interface result.

# CRESSI のダウンロードツール
https://www.cressi.com/software
を使ってダウンロードしたデータはJSONで、これをCSVにする。

# 動作
上記ダウンロードツールでダウンロードしたJSONファイルを読み込み、CSVに変換して保存する。Python版とC#版あり。

# Pythonで書いた
依存 : import json

# C#で書いた
依存 : System.Text.Json
