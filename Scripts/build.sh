#!/bin/bash

./test.sh
[  $? -ne 0 ] && exit 1

./compile.sh
[  $? -ne 0 ] && exit 2

./publish.sh
exit 0

