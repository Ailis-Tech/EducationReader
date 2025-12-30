![Static Badge](https://img.shields.io/badge/build-passing-green)
![Static Badge](https://img.shields.io/badge/license-MIT-blue)

**Over View**
* 知育用(2～5歳くらい)のアプリとして試作したものです。
* 現時点ではひらがなと数字のみ対応しています。
* 文字か数字の書かれたボタンをクリックすると、それを読み上げ、あらかじめ登録してある画像を表示するという仕様です。

**How to build**
1. Visual Studioでビルドするため、インストールします。
2. ReadContents\hiraganaおよびnumberにそれぞれ表示したい画像(jpg)を置きます。
   * hiraganaのファイル名は表示したいひらがなと同じにします。numberはimage.jpgとします。
4. slnファイルからプロジェクトを開いてビルドしてください。
5. ビルドが成功するとReadContents\bin内に実行ファイル(.exe)が生成されます。

**How to Use**
* 任意のフォルダを作り、その中に下記のようなフォルダ階層になるようにファイルを置いてください。
```
.
└── 任意のフォルダ
    ├── bin
    │   ├── Release - 実行ファイル
    │   └── Debug - 実行ファイル
    ├── hiragana
    │   ├── あ.jpg
    │   ├── い.jpg
    │   ├── う.jpg
    │   └── ...
    └── number
        └── image.jpg
```

* 上記の要領で任意のjpgファイルを追加できます。
* jpgファイルを追加することで、ボタンをクリックした際にその画像が表示されるようになります。

**Credit**
1. 音声データの生成には下記を使用させていただきました。(wav形式に変換)
   * 音読さん：https://ondoku3.com/ja/
  
**License**
* 「ReadContents」は MIT License の下で公開されています。
 [MIT license](https://choosealicense.com/licenses/mit/)
