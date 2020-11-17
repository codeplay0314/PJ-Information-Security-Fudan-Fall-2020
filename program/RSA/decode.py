import sys

d = 0
n = 0
for line in open("RSA/server/n.txt", "r"):
    n = int(line)

for line in open("RSA/server/d.txt", "r"):
    d = int(line)

cipher = int(sys.argv[1])

def pow(a, n, mod):
    res = 1
    while n:
        if n&1:
            res = res * a % mod
        a = a * a % mod
        n >>= 1
    return res

m = pow(cipher, d, n)
s = ""
for i in range(0, 64):
    s = str(m&1) + s
    m >>= 1

print(s)