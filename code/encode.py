e = 0
n = 0
for line in open("RSA/client/n.txt", "r"):
    n = int(line)

for line in open("RSA/client/e.txt", "r"):
    e = int(line)

m = 0
s = input()
for c in s:
    m = m * 2 + int(c)

def pow(a, n, mod):
    res = 1
    while n:
        if n&1:
            res = res * a % mod
        a = a * a % mod
        n >>= 1
    return res

print(s)
print(pow(m, e, n))