# UnitySVN
将 TortoiseSVN 的基础操作内嵌到 Unity，并使用快捷键操作，提高效率。这里只是添加了几个常用的操作，其他操作需要的话可以自行添加。具体命令可参见TortoiseSVN的help功能，也可以直接去官网查看相关的命令：https://tortoisesvn.net/docs/nightly/TortoiseSVN_en/tsvn-cli-main.html

## 工具介绍：
1. 将 SVN 文件夹放到 Unity 项目的 Editor 文件夹下即可，在菜单栏的 Assets->SVN 下会显示支持的所有操作
2. 带 All 的命令是跟整个工程相关的，比如说 CommitAll 是提交整个项目的修改，UpdateAll 是更新整个项目的修改
3. 不带 All 的命令跟选中的文件或文件夹相关，比如说 Commit 命令需要先选中要提交的文件或者某个文件夹下所有的文件，然后使用 `Alt+C` 快捷键提交选中

## 常用流程：
1. 使用 `Alt+Shift+C` 快捷键更新整个项目
2. 选中某个改动的文件或者某个文件夹（这个文件加下所有改动过的文件都会执行相应操作），然后使用 `Alt+C` 快捷键提交选中
3. 其他命令只是在偶尔需要的使用使用，最常用的就两个命令：`Alt+Shift+C` 和 `Alt+C` 