# CSVHelperSample
CSVHelperの使い方の練習とサンプル

## 本家
https://joshclose.github.io/CsvHelper/

## 内容
### 属性定義による出力と読み込み
Enitityクラスに属性を定義し、その定義に従っての入出力。
(Program.cs - DoNormal)

基本的な定義は DataClass.cs で完結。
そのままでは入出力できないEnumは、EnumDescriptionConverter を定義して変換する。

### Mapを定義しての出力と読み込み
Mapクラスを定義し、その定義に従っての入出力。
(Program.cs - DoMapping)

WithoutAgeDataClassMap、Age0DataClassMap で定義し、DataClass.cs の設定はみない。


### 汎用的なメソッドサンプル
Genericsで比較的汎用的に使えるようにするためのサンプル。
(Program.cs - DoGenerics)
(Program.cs - DoStruct)


## ライセンス
本家CsvHelperの取り決めに準じます

