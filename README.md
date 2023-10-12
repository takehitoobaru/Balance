# FallFoods
・タイトル画面
![Title](https://github.com/takehitoobaru/Balance/assets/88570413/00fd47d4-500a-4ae4-bf21-5b95a5a19ec3)
・ゲーム画面
![InGame](https://github.com/takehitoobaru/Balance/assets/88570413/f77f3c34-1974-4aff-af77-e7b90a939bd1)
・リザルト画面
![Result](https://github.com/takehitoobaru/Balance/assets/88570413/5b917b18-8a2d-458e-aa69-746d0affe016)

ゲームプレイURL  
https://takehitoobaru.github.io/Balance/
# 操作説明
プレイヤーは左右の矢印キーで移動して、落ちてくる食べ物を食べます。  
制限時間内にたくさん食べてスコアを伸ばしましょう。  
食べ物には炭水化物、肉、魚、野菜の値が割り振られています。  
食べ物の各値の割合が小さすぎる、もしくは大きすぎる場合、即ゲーム終了となります。  
食べ物以外のものを取得するとスコアがダウンします。
# 制作環境
Unity 2022.3.8f1
# テーマの解釈
思いついたのは「食事バランス」  
落ちてくる食材をバランスよく食べることをテーマとした
# 仕様書
・操作は矢印キー  
・プレイヤーは左右に動き、落ちてくる食べ物を食べる。  
・食べ物は炭水化物、肉、魚、野菜の項目に分かれている。  
・食べ物にはスコア、属性値が割り振られており、食べると増加する。  
・属性値の合計から割合を算出。一定割合を超えるか制限時間で終了。
　リザルトシーンへ。  
・食べ物以外は取得するとスコア減少  
・属性値の割合は棒グラフにして表示。途中から見れなくなる
# 使用したデザインパターン
・Singleton  
・ObjectPooling  
・Eventを用いたObserver  
・State
# 使用アセット
・ピクセルガロー  
  https://hpgpixer.jp/

・ぴぽや  
  https://pipoya.net/

・効果音ラボ  
  https://soundeffect-lab.info/

・魔王魂  
  https://maou.audio/

・DOVA-SYNDROME  
  https://dova-s.jp/
