PUSHD %~dp0packages\redis-64.3.0.501\tools\
start cmd /C call redis-server.exe
POPD
start /B /wait %~dp0inMemoryDbBenchmark\bin\x64\Release\inMemoryDbBenchmark.exe >> out.log
