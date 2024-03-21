#!/bin/bash -vx

mk_folder(){
read -p "Give me a path to folder ypu want to create: " dpath
mkdir ${dpath}
}

download_image(){
url="https://student.labranet.jamk.fi/~pekkju/script/tux.png"
wget ${url} -q  -P ${dpath}
mv ${dpath}/tux.png ${dpath}/linux-tux.png
}

change_perm(){
chmod 700 ${dpath}
chmod 700 ${dpath}/linux-tux.png
}

mk_folder

download_image

change_perm
