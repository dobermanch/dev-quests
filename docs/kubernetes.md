# Kubernetes

---

## 🚀 What Is Kubernetes?

Kubernetes (often abbreviated as K8s) is an open-source platform for automating deployment, scaling, and management of containerized applications. Originally developed by Google and now maintained by the CNCF, it’s the industry standard for container orchestration.

### 🧱 Core Architectural Components

Kubernetes follows a master-worker (control plane–node) architecture:

### 🧭 Control Plane (Master Node)

Responsible for managing the cluster and making global decisions.

| Component              | Role                                                                 |
|------------------------|----------------------------------------------------------------------|
| kube-apiserver         | Front-end for the Kubernetes API; all communication goes through it  |
| etcd                   | Distributed key-value store for cluster state                        |
| kube-scheduler         | Assigns Pods to nodes based on resource availability and constraints |
| kube-controller-manager| Runs controllers to maintain desired state (e.g., replicas, jobs)    |
| cloud-controller-manager| Integrates with cloud provider APIs (e.g., load balancers)          |

### 🖥️ Worker Nodes

Run the actual application workloads (Pods).

| Component         | Role                                                      |
|-------------------|----------------------------------------------------------|
| kubelet           | Agent that ensures containers are running as expected    |
| kube-proxy        | Handles networking and load balancing between Pods/Services|
| container runtime | Executes containers (e.g., containerd, CRI-O)            |

### 🔄 How It All Works Together

1. User submits a request (e.g., deploy a Pod) via kubectl or API.
2. API server validates and stores the desired state in etcd.
3. Scheduler assigns the Pod to a suitable node.
4. Controller manager ensures the desired state is maintained.
5. Kubelet on the node pulls the container image and starts the Pod.
6. Kube-proxy sets up networking so the Pod can communicate.

### 🧠 Key Concepts

- **Pod:** Smallest deployable unit; wraps one or more containers.
- **Service:** Stable endpoint to access Pods.
- **Deployment:** Manages rolling updates and replica sets.
- **Ingress:** Routes external traffic to internal services.
- **ConfigMap & Secret:** Externalize configuration and sensitive data.
- **Volume & PVC:** Persistent storage for stateful apps.
- **HPA & VPA:** Autoscaling based on metrics.

---

## 🖥️ What is a Node?

In Kubernetes, a node is a physical or virtual machine that runs your application workloads. It’s the fundamental building block of a Kubernetes cluster—where containers actually live and execute. 🧱

### 🖥️ Types of Nodes

| Node Type           | Role                                                    |
|---------------------|--------------------------------------------------------|
| Control Plane Node  | Manages the cluster (scheduling, scaling, health checks)|
| Worker Node         | Runs application Pods and handles networking/storage    |

### 🔧 Key Components on a Node

Every node—whether control plane or worker—runs several critical services:

- **kubelet:** Talks to the control plane and ensures containers are running as expected
- **kube-proxy:** Manages networking rules and routes traffic to the right Pods
- **Container Runtime:** Runs containers (e.g., containerd, CRI-O)

### 📦 What Happens on a Worker Node?

- Pods are scheduled here by the control plane
- Containers inside Pods run your app logic
- Volumes are mounted for persistent storage
- Network rules are applied for service discovery and communication

### 🧠 Node Lifecycle & Management

- Nodes can self-register with the cluster via the kubelet
- You can cordon a node to prevent new Pods from being scheduled
- You can drain a node to safely evict Pods before maintenance
- Node health is monitored via heartbeats and status conditions

### 🔍 Useful Commands

```sh
kubectl get nodes
kubectl describe node <node-name>
kubectl cordon <node-name>
kubectl drain <node-name> --ignore-daemonsets
```

---

## 📦 What Is a Pod?

A Pod is the smallest deployable unit in Kubernetes. It can contain one or more containers that share the same network, volumes, and lifecycle.

### 🔧 Key Characteristics

- **Shared IP & Port space:** Containers communicate via localhost
- **Shared Storage:** Mounted volumes accessible across containers
- **Tight Coupling:** Containers are colocated and often work in tandem (e.g., sidecar patterns)

### 🗂️ Pod Lifecycle Phases

| Phase             | Description                                 |
|-------------------|---------------------------------------------|
| Pending           | Pod scheduled but not yet running           |
| Running           | Pod is active and all containers have started|
| Succeeded         | All containers exited successfully          |
| Failed            | One or more containers exited with error    |
| CrashLoopBackOff  | Container repeatedly fails and restarts     |

Check with:

```sh
kubectl get pods
kubectl describe pod <name>
```

### 🔍 Single vs Multi-Container Pods

**Single Container (most common):**

```yaml
spec:
  containers:
  - name: web
    image: nginx
```

**Multi-Container (e.g., with sidecar):**

```yaml
spec:
  containers:
  - name: main
    image: my-app
  - name: log-agent
    image: fluentd
```

Used for logging, proxying, or monitoring agents running alongside the main app.

### 🚨 Probes: Health Checks for Pods

- **Readiness Probe:** Controls traffic flow
- **Liveness Probe:** Restarts container on failure

**Example:**

```yaml
livenessProbe:
  httpGet:
    path: /healthz
    port: 8080
  initialDelaySeconds: 5
  periodSeconds: 10
```

### 🧠 Real-World Tips

- Always set resource limits (cpu, memory) to avoid noisy neighbors
- Use labels for grouping and targeting pods (app=my-app)
- Avoid running everything in default namespace or with default ServiceAccount
- Monitor with `kubectl logs`, `kubectl top pods`, and events

---

## 🚀 What Are Init Containers?

Init containers are special containers that run before the main containers in a Pod. They help set up dependencies, wait for resources, or perform checks before the actual workload starts.

### 🔧 Key Features

- Run sequentially—each init container must succeed before the next starts
- The main app containers won’t start until all init containers succeed
- Have separate specs from regular containers (can use different images/tools)
- Perfect for setting up configuration, downloading files, waiting for services

### 📦 Real-World Use Cases

- 🔁 Wait for a database or dependent service to be available
- 🔑 Fetch secrets or config files from external systems (e.g., Vault)
- ⚙️ Set up filesystem structure or perform migrations
- ✅ Run pre-checks or validations before app boot

### 🧪 Example Pod with Init Container

```yaml
apiVersion: v1
kind: Pod
metadata:
  name: demo-init
spec:
  initContainers:
  - name: wait-db
    image: busybox
    command: ['sh', '-c', 'until nc -z db-service 5432; do echo waiting; sleep 2; done']
  containers:
  - name: app
    image: nginx
    ports:
    - containerPort: 80
```

**In this example:**

- The init container uses nc (netcat) to wait for a database to be ready.
- Once it exits successfully, the main NGINX container starts.

### 🧠 Tips & Best Practices

- Init containers can’t be restarted individually—if one fails, the entire Pod is stuck
- Don’t use long-running processes in init containers—keep them fast and purposeful
- Use multiple init containers for ordered, modular initialization
- Combine with readiness probes and startup probes for layered reliability

---

## 🧩 What Is a Sidecar?

A sidecar container runs alongside your main application container in the same Pod. It shares the pod's network and storage space, enabling tight interaction between containers. It’s not part of the core app, but augments it—think of it as "attached but independent."

### 🧰 Common Use Cases

| Use Case         | Description                                      |
|------------------|--------------------------------------------------|
| Logging agents   | Collect and forward logs (e.g., Fluentd, Filebeat)|
| Proxies          | Add security, caching, or routing (e.g., Envoy)  |
| Metrics exporters| Collect metrics for monitoring (e.g., Prometheus)|
| Config/secrets   | Sync from external sources like Vault            |
| Updater/patchers | Fetch updates, sync configs, or apply dynamic content|

### 📦 Example Pod with a Sidecar

```yaml
apiVersion: v1
kind: Pod
metadata:
  name: app-with-sidecar
spec:
  containers:
  - name: main-app
    image: my-app:latest
    ports:
    - containerPort: 8080
  - name: log-sidecar
    image: fluentd
    volumeMounts:
    - name: logs
      mountPath: /var/log/app
  volumes:
  - name: logs
    emptyDir: {}
```

- main-app writes logs to /var/log/app
- log-sidecar reads those logs and ships them elsewhere

Both containers share the emptyDir volume and network space.

### 🔍 Sidecar Advantages

- 🧩 Modular Design: Clean separation of concerns
- 🔁 Lifecycle Coupling: Starts/stops with the main app
- 📡 Inter-container Communication: Via shared localhost and volumes
- 💡 Reusability: Can swap in different sidecars without touching the app code

### ⚠️ Gotchas & Best Practices

- Don’t overload the Pod with too many sidecars—resource contention is real
- Keep sidecars stateless and lightweight whenever possible
- Use readiness probes carefully to avoid premature traffic routing
- Monitor sidecars just like main apps—they can fail silently

---

## 🏷️ Metadata in Kubernetes

Metadata is foundational to every resource.

### 📌 Core Fields

- **name:** Unique identifier within a namespace
- **namespace:** Logical grouping (default if not specified)
- **labels:** Key-value pairs for grouping and selection
- **annotations:** Key-value pairs for arbitrary, non-identifying metadata

**Example:**

```yaml
metadata:
  name: my-app
  namespace: production
  labels:
    app: web
    tier: frontend
  annotations:
    maintainer: "sergii@example.com"
    description: "Handles user traffic"
```

### 🧠 Labels vs Annotations

| Feature   | Labels                        | Annotations                       |
|-----------|-------------------------------|-----------------------------------|
| Purpose   | Resource selection/filtering  | Metadata for tools/users          |
| Used By   | Controllers, services, deployments | Custom tooling, audits, docs   |
| Constraints| Limited size, indexing supported | Unindexed, can be large/arbitrary|
| Typical Use| Matching pods to services     | Notes like Git commit, build info |

### 💡 Common Annotation Use Cases

- Link to source code: git.repo/url, git.commit.sha
- Owner info: contact-email, team-owner
- Operational flags: sidecar-injection: "enabled"
- Monitoring: prometheus.io/scrape: "true"
- Certificates: cert-manager.io/issuer

### 🧪 Practical Example in a Deployment

```yaml
apiVersion: apps/v1
kind: Deployment
metadata:
  name: user-api
  labels:
    app: api
    environment: dev
  annotations:
    git.commit: "a1b2c3d"
    prometheus.io/scrape: "true"
spec:
  replicas: 2
  selector:
    matchLabels:
      app: api
  template:
    metadata:
      labels:
        app: api
```

This example lets Prometheus auto-discover metrics, and tracks which Git commit deployed the app—hugely useful for observability.

---

## 🩺 Health Probes: Observability & Self-Healing

### 🔍 Liveness Probe

- Checks if the container is **stuck or dead**.
- If failed → Kubernetes restarts the container.
- Helps fix infinite loops, deadlocks, and failed threads.

```yaml
livenessProbe:
  httpGet:
    path: /healthz
    port: 8080
  initialDelaySeconds: 5
  periodSeconds: 10
```

### 🟢 Readiness Probe

- Determines if the container is ready to **serve traffic**.
- Failed probe removes the pod from Services—but does NOT restart it.
- Protects against sending traffic to broken or booting apps.

```yaml
readinessProbe:
  httpGet:
    path: /ready
    port: 8080
  initialDelaySeconds: 5
  periodSeconds: 10
```

### 🚦 Startup Probe

- Ensures apps that take a long time to boot aren’t killed prematurely.
- Only used during startup window.
- Helps distinguish slow startup from deadlock.

```yaml
startupProbe:
  httpGet:
    path: /startup
    port: 8080
  failureThreshold: 30
  periodSeconds: 10
```

---

## 🚀 What Is a Deployment?

A Deployment is a higher-level abstraction that tells Kubernetes how to create and manage Pods for your application. It ensures your desired state—number of replicas, container image, update strategy—is continuously maintained.

### 🧱 Key Features

- ✨ Declarative management: Define what you want, and Kubernetes makes it happen
- 🔁 Rolling updates: Seamless app upgrades with zero downtime
- ↩️ Rollbacks: Automatically revert if an update goes south
- 📦 ReplicaSets: Behind the scenes, Deployments use these to manage Pod scaling

### 📦 Example YAML

```yaml
apiVersion: apps/v1
kind: Deployment
metadata:
  name: web-api
spec:
  replicas: 3
  selector:
    matchLabels:
      app: web-api
  strategy:
    type: RollingUpdate
  template:
    metadata:
      labels:
        app: web-api
    spec:
      containers:
      - name: app
        image: my-api:v1
        ports:
        - containerPort: 80
```

This deployment maintains 3 replicas of your web-api app, upgrading pods using a rolling strategy.

### 🔄 Deployment Lifecycle Commands

| Command                                 | Description                       |
|------------------------------------------|-----------------------------------|
| kubectl apply -f deploy.yaml             | Create/update deployment          |
| kubectl rollout status deploy/web-api    | Monitor update progress           |
| kubectl rollout undo deploy/web-api      | Roll back to previous version     |
| kubectl rollout restart deploy/web-api   | Restart all pods manually         |
| kubectl describe deploy/web-api          | See current state and history     |

### ⚠️ Common Challenges

- ❌ Image tag not updated = deployment doesn’t change
- 📉 Failing readiness probes = rollout stalls
- 📦 Old ReplicaSets linger = unexpected resource usage
- 🧪 Forgetting resource limits = noisy neighbor issues

### 🧠 Tips for Production

- Always pin image versions (my-api:v1.2.3) to avoid accidental updates
- Use health probes (readiness, liveness) to guard rollouts
- Leverage labels for tracking and targeting deployments
- Integrate with CI/CD to automate deployment triggers

---

## 🔄 What Is a Rolling Update?

A rolling update gradually replaces old Pods with new ones in a Deployment. Instead of stopping everything at once, Kubernetes updates Pods one (or a few) at a time, ensuring your app stays available.

### 🧱 How It Works

- New Pods are created with the updated spec (e.g., new image version)
- Old Pods are terminated only after the new ones are healthy
- Traffic is routed only to ready Pods via Services

This is the default strategy for Deployments.

### ⚙️ Configuration Options

```yaml
strategy:
  type: RollingUpdate
  rollingUpdate:
    maxUnavailable: 1
    maxSurge: 1
```

| Field           | Description                                                        |
|-----------------|--------------------------------------------------------------------|
| maxUnavailable  | Max number of Pods that can be unavailable during the update (default: 25%) |
| maxSurge        | Max number of extra Pods created temporarily during the update (default: 25%)|

These can be set as integers or percentages.

### 📦 Example Update Command

```sh
kubectl set image deployment/web-app web-app=myapp:v2
kubectl rollout status deployment/web-app
```

This updates the image and monitors the rollout.

### ↩️ Rollbacks

If something breaks, you can undo it:

```sh
kubectl rollout undo deployment/web-app
```

Kubernetes keeps a history of revisions so you can revert safely.

### 🧠 Best Practices

- Use readiness probes to ensure traffic only hits healthy Pods
- Monitor with kubectl rollout status and Prometheus/Grafana
- Pin image versions (myapp:v1.2.3) to avoid accidental updates
- Automate updates via CI/CD pipelines

---

## 📈 What Is Horizontal Pod Autoscaler (HPA)

The Horizontal Pod Autoscaler is a Kubernetes controller that:

- Monitors resource usage (CPU, memory, etc.)
- Compares it against a target threshold
- Scales the number of pod replicas up or down to meet demand

It’s ideal for stateless workloads like web servers, APIs, or stream processors.

### ⚙️ How HPA Works

- **Metrics Collection:** Uses the Metrics Server or custom APIs to gather pod-level metrics.
- **Target Comparison:** Example: If average CPU usage exceeds 70%, HPA increases replicas.
- **Scaling Decision:** Calculates desired replicas using:

  ```yaml
  desiredReplicas = ceil[currentReplicas × currentMetric / targetMetric]
  ```

- **Update Deployment:** Adjusts the .spec.replicas field of the target Deployment or StatefulSet.

### 📦 Example YAML

```yaml
apiVersion: autoscaling/v2
kind: HorizontalPodAutoscaler
metadata:
  name: web-api-hpa
spec:
  scaleTargetRef:
    apiVersion: apps/v1
    kind: Deployment
    name: web-api
  minReplicas: 2
  maxReplicas: 10
  metrics:
  - type: Resource
    resource:
      name: cpu
      target:
        type: Utilization
        averageUtilization: 70
```

This HPA keeps CPU usage around 70% and scales between 2 and 10 replicas.

### 🧠 Best Practices

- ✅ Set resource requests/limits in your Pod specs—HPA needs them to calculate utilization.
- 🔍 Use `kubectl top pods` to verify metrics are flowing.
- 🛡️ Combine with PodDisruptionBudgets to avoid aggressive scale-downs.
- 📊 Monitor with Prometheus/Grafana for visibility and tuning.

### 🧪 Useful Commands

| Command                                                      | Purpose                        |
|--------------------------------------------------------------|--------------------------------|
| kubectl get hpa                                              | View current autoscaler status |
| kubectl describe hpa <name>                                  | Inspect metrics and scaling decisions |
| kubectl autoscale deploy <name> --cpu-percent=70 --min=2 --max=10 | Create HPA via CLI            |

---

## 🧠 What Is a StatefulSet?

A StatefulSet is a Kubernetes controller that manages the deployment and scaling of a set of Pods with unique, persistent identities and stable storage. Unlike Deployments, which treat Pods as interchangeable, StatefulSets preserve Pod identity across restarts and rescheduling.

### 🔧 Key Features

| Feature               | Description                                                      |
|-----------------------|------------------------------------------------------------------|
| Stable Network Identity | Each Pod gets a predictable DNS name like web-0, web-1, etc.   |
| Persistent Storage    | Each Pod gets its own PersistentVolumeClaim (PVC) via volumeClaimTemplates |
| Ordered Deployment    | Pods are created and terminated in a defined sequence            |
| Sticky Identity       | Pod names and storage persist even if the Pod is rescheduled     |

### 📦 Example Use Case

Running a replicated database like PostgreSQL, MongoDB, or Kafka, where:

- Each node has a distinct role (e.g., leader/follower)
- You need consistent hostnames for clustering
- Data must persist across Pod restarts

### 🛠️ Sample YAML Snippet

```yaml
apiVersion: apps/v1
kind: StatefulSet
metadata:
  name: web
spec:
  serviceName: "web"
  replicas: 3
  selector:
    matchLabels:
      app: web
  template:
    metadata:
      labels:
        app: web
    spec:
      containers:
      - name: nginx
        image: nginx
        volumeMounts:
        - name: www
          mountPath: /usr/share/nginx/html
  volumeClaimTemplates:
  - metadata:
      name: www
    spec:
      accessModes: ["ReadWriteOnce"]
      resources:
        requests:
          storage: 1Gi
```

This creates 3 Pods: web-0, web-1, web-2, each with its own PVC and hostname.

### 🧠 Best Practices

- Use a Headless Service (clusterIP: None) to enable stable DNS
- Avoid scaling down without understanding volume retention—PVCs aren’t deleted automatically
- Use Pod index labels (apps.kubernetes.io/pod-index) for routing or metrics
- Combine with Init Containers for bootstrapping and Probes for health checks

---

## 🧠 What Is a DaemonSet?

A DaemonSet is a Kubernetes controller that:

- Ensures one Pod per node
- Automatically adds Pods to new nodes
- Cleans up Pods when nodes are removed
- Ideal for background tasks that must run everywhere

### 🔧 Common Use Cases

| Use Case         | Description                                      |
|------------------|--------------------------------------------------|
| Log collection   | Run Fluentd, Filebeat, or Logstash on all nodes  |
| Monitoring agents| Deploy Prometheus Node Exporter or Datadog       |
| Network plugins  | Calico, Cilium, or Weave Net                     |
| Storage daemons  | Ceph, GlusterFS, or CSI drivers                  |
| Security scanners| Run kube-bench or Falco on every node            |

### 📦 Example DaemonSet YAML

```yaml
apiVersion: apps/v1
kind: DaemonSet
metadata:
  name: node-monitor
  namespace: monitoring
spec:
  selector:
    matchLabels:
      app: node-monitor
  template:
    metadata:
      labels:
        app: node-monitor
    spec:
      containers:
      - name: exporter
        image: prom/node-exporter
        ports:
        - containerPort: 9100
```

This ensures the node-exporter runs on every node in the monitoring namespace.

### 🧭 Scheduling & Targeting Nodes

- Use nodeSelector or affinity to limit DaemonSet to specific nodes
- Use tolerations to run on tainted nodes (e.g., control plane or GPU nodes)
- Combine with priorityClassName to ensure scheduling even under pressure

### 🔄 Updates & Rollouts

DaemonSets support rolling updates via:

```yaml
updateStrategy:
  type: RollingUpdate
```

You can control how many Pods update at once using maxUnavailable.

### 🧠 Tips & Gotchas

- DaemonSet Pods are not scaled manually—they scale with node count
- Avoid deleting Pods directly—let the controller manage them
- Use headless Services or hostPort for communication
- Monitor with `kubectl get ds`, `kubectl describe ds`, and `kubectl get pods -o wide`

---

## 🧬 What Is a ReplicaSet?

A ReplicaSet is a controller that maintains a stable set of Pod replicas. If a Pod crashes or is deleted, the ReplicaSet automatically creates a new one to meet the desired count.

### 🧱 Key Components

| Component | Description                                 |
|-----------|---------------------------------------------|
| replicas  | Desired number of Pods to maintain          |
| selector  | Label-based filter to identify which Pods belong to the ReplicaSet |
| template  | Pod spec used to create new Pods            |

### 📦 Example YAML

```yaml
apiVersion: apps/v1
kind: ReplicaSet
metadata:
  name: web-rs
spec:
  replicas: 3
  selector:
    matchLabels:
      app: web
  template:
    metadata:
      labels:
        app: web
    spec:
      containers:
      - name: nginx
        image: nginx:latest
        ports:
        - containerPort: 80
```

This ensures 3 Pods labeled app=web are always running with the NGINX container.

### 🧠 How It Works

- Watches for Pods matching its selector
- Creates new Pods if count drops below desired
- Deletes excess Pods if count exceeds desired
- Automatically replaces failed Pods

### ⚙️ Useful Commands

| Command                                 | Purpose                        |
|------------------------------------------|--------------------------------|
| kubectl get rs                          | List ReplicaSets               |
| kubectl describe rs <name>               | View details                   |
| kubectl scale rs <name> --replicas=5     | Change replica count           |
| kubectl delete rs <name>                 | Delete ReplicaSet and its Pods |

### 🧠 Best Practices

- Use Deployments instead of raw ReplicaSets for rolling updates and versioning
- Avoid overlapping selectors—ReplicaSets can “adopt” Pods unintentionally
- Always match selector and template.labels to avoid API rejections

---

## 🔐 What Is a Secret?

A Secret is a Kubernetes object that stores confidential data in key-value pairs. Unlike ConfigMaps, Secrets are intended for sensitive content and can be mounted into Pods or injected as environment variables.

### 🔧 How Secrets Work

| Feature   | Description                                                      |
|-----------|------------------------------------------------------------------|
| Storage   | Base64-encoded by default; can be encrypted at rest in etcd      |
| Access    | Controlled via RBAC; scoped to namespaces                        |
| Usage     | Mounted as volumes or injected as env vars                       |
| Types     | Opaque, TLS, docker-registry, basic-auth, ssh-auth, etc.         |

### 📦 Example: Create an Opaque Secret

```sh
kubectl create secret generic db-creds \
  --from-literal=username=admin \
  --from-literal=password='S!B*d$zDsb='
```

This creates a secret named db-creds with two keys: username and password.

### 🧪 Injecting Secrets into a Pod

**As Environment Variables:**

```yaml
env:
- name: DB_USER
  valueFrom:
    secretKeyRef:
      name: db-creds
      key: username
```

**As Mounted Files:**

```yaml
volumes:
- name: secret-vol
  secret:
    secretName: db-creds
volumeMounts:
- name: secret-vol
  mountPath: "/etc/secrets"
```

### 🔐 TLS & Cert Secrets

For HTTPS or Ingress TLS termination:

```sh
kubectl create secret tls tls-cert \
  --cert=./tls.crt \
  --key=./tls.key
```

Used in Ingress:

```yaml
tls:
- hosts:
    - myapp.com
  secretName: tls-cert
```

### 🛡️ Best Practices

- ✅ Enable encryption at rest for etcd
- ✅ Use RBAC to restrict access
- ✅ Rotate secrets regularly
- ✅ Avoid mounting secrets into containers that don’t need them
- ✅ Consider external secret managers (Vault, AWS Secrets Manager)

---

## ⚙️ What Is a ConfigMap?

A ConfigMap is a Kubernetes object used to store non-sensitive configuration data as key-value pairs. It allows you to inject settings into Pods without baking them into container images.

### 📦 Common Use Cases

| Use Case           | Description                                 |
|--------------------|---------------------------------------------|
| Environment variables | Inject config values into containers      |
| Config files       | Mount as files inside Pods                  |
| Command-line arguments | Pass config via CLI flags               |
| App initialization | Provide boot-time parameters                |

### 🛠️ Example ConfigMap YAML

```yaml
apiVersion: v1
kind: ConfigMap
metadata:
  name: app-config
data:
  LOG_LEVEL: debug
  API_URL: https://api.internal.local
```

You can inject this into a Pod as:

**Environment Variables:**

```yaml
env:
- name: LOG_LEVEL
  valueFrom:
    configMapKeyRef:
      name: app-config
      key: LOG_LEVEL
```

**Mounted Volume:**

```yaml
volumes:
- name: config-vol
  configMap:
    name: app-config
volumeMounts:
- name: config-vol
  mountPath: /etc/config
```

### 🧠 Best Practices

- ✅ Use ConfigMaps for non-sensitive data only (use Secrets for credentials)
- 🛑 Avoid hardcoding config in container images
- 🔁 Use `kubectl rollout restart` to reload updated ConfigMaps
- 📦 Use `immutable: true` to lock critical configs
- 🔍 Use `kubectl describe configmap <name>` to inspect contents

### 🔄 Updating ConfigMaps

You can update via:

```sh
kubectl edit configmap app-config
```

Or reapply a new version:

```sh
kubectl apply -f app-config.yaml
```

Mounted volumes will reflect changes automatically (with a delay), but env vars require a Pod restart.

---

## 📄 What Are Certificates in Kubernetes?

Certificates are digital credentials used to:

- Encrypt traffic via TLS (Transport Layer Security)
- Authenticate identities of nodes, users, and services
- Establish trust between components using PKI (Public Key Infrastructure)

They’re used by:

- Control plane components (API server, etcd, kubelet)
- Ingress controllers for HTTPS
- Workloads needing secure service-to-service communication

### 🧰 Types of Certificates

| Certificate Type   | Purpose                                         |
|--------------------|------------------------------------------------|
| TLS Certificates   | Encrypt traffic between clients and services    |
| Client Certificates| Authenticate users or services to the API       |
| Serving Certificates| Secure endpoints like Ingress or web apps      |
| CA Certificates    | Sign and validate other certificates            |

### 🛠️ How Certificates Are Managed

Kubernetes has a built-in Certificate Authority (CA) that issues certs for internal components. For custom workloads, you can:

- Use cert-manager to automate issuance and renewal
- Manually create certs using OpenSSL or CFSSL
- Submit CertificateSigningRequests (CSR) to the Kubernetes API

**Example: TLS Secret for Ingress**

```sh
kubectl create secret tls tls-cert \
  --cert=./tls.crt \
  --key=./tls.key \
  --namespace=my-app
```

Then reference it in your Ingress:

```yaml
tls:
- hosts:
    - myapp.example.com
  secretName: tls-cert
```

### 🔁 Automating with cert-manager

Cert-manager is a Kubernetes-native controller that:

- Issues certs from Let’s Encrypt, Vault, or self-signed sources
- Automatically renews expiring certs
- Integrates with Ingress, Services, and custom resources

**Example annotation for Ingress:**

```yaml
annotations:
  cert-manager.io/cluster-issuer: "letsencrypt-prod"
```

### 🧠 Best Practices

- ✅ Enable encryption at rest for Secrets in etcd
- 🔁 Automate renewal with cert-manager or custom controllers
- 🔍 Monitor expiration dates and set alerts
- 🛡️ Use RBAC to restrict access to certificate-related resources
- 📦 Store CA bundles in ConfigMaps for trust propagation

---

## 💾 Volumes & PersistentVolumeClaims (PVCs)

### 📦 Volumes: The Basics

A Volume in Kubernetes is a directory accessible to containers in a Pod. Unlike container-local storage, volumes persist across container restarts (but not Pod restarts).

#### 🔹 Common Volume Types

| Type                | Description                                 |
|---------------------|---------------------------------------------|
| emptyDir            | Temporary storage, erased when Pod stops    |
| hostPath            | Mounts a file or directory from the node    |
| configMap           | Mounts config data                          |
| secret              | Mounts sensitive data                       |
| persistentVolumeClaim| Mounts a PersistentVolume via PVC          |

### 🧠 PersistentVolume (PV)

A PersistentVolume is a cluster-wide storage resource provisioned by an admin or dynamically via a StorageClass.

#### 🔧 Key Attributes

- Capacity: Size of the volume (e.g., 10Gi)
- Access Modes: ReadWriteOnce, ReadOnlyMany, ReadWriteMany
- Reclaim Policy: What happens when PVC is deleted (Retain, Delete, Recycle)
- Volume Type: NFS, iSCSI, CSI, cloud disk, etc.

### 📨 PersistentVolumeClaim (PVC)

A PVC is a request for storage by a user. It specifies:

- Desired size
- Access mode
- Optional StorageClass

Kubernetes matches the PVC to an available PV or provisions one dynamically.

**Example PVC:**

```yaml
apiVersion: v1
kind: PersistentVolumeClaim
metadata:
  name: data-claim
spec:
  accessModes:
    - ReadWriteOnce
  resources:
    requests:
      storage: 5Gi
  storageClassName: fast-ssd
```

### 🔗 Binding PVC to PV

Once a PVC is created:

- Kubernetes finds a matching PV (or provisions one)
- PVC and PV are bound (one-to-one)
- Pod can mount the PVC as a volume

**Pod Usage:**

```yaml
volumes:
- name: data-vol
  persistentVolumeClaim:
    claimName: data-claim
```

### 🔄 Lifecycle Overview

- Provisioning: PVs created statically or dynamically
- Binding: PVC matched to PV
- Using: Pod mounts PVC as volume
- Reclaiming: PVC deleted → PV handled per reclaim policy

### 🧠 Best Practices

- ✅ Use StorageClass for dynamic provisioning
- 🛡️ Set appropriate accessModes and reclaimPolicy
- 🔍 Monitor PVC status (Bound, Pending, Lost)
- 📦 Use volumeMounts carefully to avoid path conflicts
- 🔁 Resize PVCs only if supported by the StorageClass

---

## 🔐 RBAC: Role-Based Access Control

RBAC governs who can do what in the cluster.

### 🔧 Core Concepts

| Concept             | Description                                               |
|---------------------|----------------------------------------------------------|
| Role                | Grants permissions within a namespace (e.g., read pods, create secrets) |
| ClusterRole         | Grants cluster-wide permissions (e.g., list nodes, access all namespaces) |
| RoleBinding         | Binds a Role to a user/serviceAccount within a namespace |
| ClusterRoleBinding  | Binds a ClusterRole to a subject at cluster scope        |

### 🧠 Example Use Case

You want a data-ingestion ServiceAccount to read from secrets and create Pods in telemetry-ns.

**Role:**

```yaml
kind: Role
apiVersion: rbac.authorization.k8s.io/v1
metadata:
  namespace: telemetry-ns
  name: telemetry-reader
rules:
- apiGroups: [""]
  resources: ["pods", "secrets"]
  verbs: ["get", "list", "create"]
```

**RoleBinding:**

```yaml
kind: RoleBinding
apiVersion: rbac.authorization.k8s.io/v1
metadata:
  name: bind-ingestion
  namespace: telemetry-ns
subjects:
- kind: ServiceAccount
  name: data-ingestion
  namespace: telemetry-ns
roleRef:
  kind: Role
  name: telemetry-reader
  apiGroup: rbac.authorization.k8s.io
```

### 🧾 ServiceAccounts

ServiceAccounts are Kubernetes identities used by Pods to interact with the API server. They replace static credentials or API keys.

#### 🔍 Key Features

- Automatically injected into Pods (`/var/run/secrets/kubernetes.io/serviceaccount`)
- Scoped to a namespace
- Can be assigned specific RBAC roles
- Frequently used by controllers, apps, jobs, CI/CD pipelines

**YAML Example:**

```yaml
apiVersion: v1
kind: ServiceAccount
metadata:
  name: data-ingestion
  namespace: telemetry-ns
```

Then bind it using RBAC as shown above.

### 🛡️ Best Practices

- Use dedicated ServiceAccounts per workload to limit blast radius
- Don’t run everything as default ServiceAccount
- Rotate ServiceAccount tokens periodically (using projected tokens)
- Enforce least privilege principle with tightly scoped roles
- Audit access using tools like OPA, Kyverno, or native audit logs

---

## 🌐 What Is a Service in Kubernetes?

A Service is an abstraction that defines a logical set of Pods and a policy to access them. Since Pods can die and be recreated, their IPs aren't reliable—Services provide a stable endpoint to connect to them.

### 🔧 Types of Services

| Service Type   | Description                                   | Use Case Example                  |
|----------------|-----------------------------------------------|-----------------------------------|
| ClusterIP      | Default type, accessible only within the cluster | Internal microservice communication|
| NodePort       | Exposes service on each Node’s IP at a static port | Access from outside the cluster for dev/test |
| LoadBalancer   | Provisions an external load balancer (cloud provider integration) | Public-facing services in managed Kubernetes |
| ExternalName   | Maps to an external DNS name via CNAME        | Proxy external database or API     |
| Headless       | No cluster IP—used for direct pod discovery   | StatefulSets, databases needing direct access |

**Sample YAML: ClusterIP Service**

```yaml
apiVersion: v1
kind: Service
metadata:
  name: internal-api
spec:
  selector:
    app: my-api
  ports:
    - protocol: TCP
      port: 80
      targetPort: 8080
  type: ClusterIP
```

This routes traffic from port 80 on the Service to port 8080 on selected Pods labeled app=my-api.

### 🔁 Service Discovery

Services are automatically assigned a DNS name: `service-name.namespace.svc.cluster.local`. Pods in the same namespace can discover them via DNS or environment variables injected by Kubernetes.

### ⚖️ Load Balancing & Session Affinity

- Kube-proxy (IPTables/IPVS) load balances traffic across matching Pods.
- You can enable `sessionAffinity: ClientIP` for sticky sessions if needed.

### 🧠 Expert Tips

- Use Headless Services + StatefulSets for direct control (e.g., Cassandra, Kafka).
- Combine Ingress with ClusterIP Services for path-based routing and TLS.
- Don't rely on NodePort for production—it’s fragile and hard to manage.
- For multi-cluster communication, use Service Mesh (Istio, Linkerd) + Gateway API.

---

## 🌐 What Is Ingress?

An Ingress is a Kubernetes API object that defines rules for routing external traffic to services inside your cluster. It’s like a reverse proxy that understands URLs, hostnames, and paths.

Without Ingress, you'd need a separate LoadBalancer or NodePort for each service. With Ingress, you consolidate access through a single entry point.

### 🧭 Key Components

| Component         | Role                                             |
|-------------------|--------------------------------------------------|
| Ingress Resource  | Defines routing rules (host/path → service)      |
| Ingress Controller| Implements the rules (e.g., NGINX, Traefik, HAProxy)|
| Backend Services  | Internal services that receive traffic           |
| TLS Secrets       | Optional certs for HTTPS termination             |

**Example Ingress YAML**

```yaml
apiVersion: networking.k8s.io/v1
kind: Ingress
metadata:
  name: app-ingress
  annotations:
    nginx.ingress.kubernetes.io/rewrite-target: /
spec:
  tls:
  - hosts:
    - app.example.com
    secretName: tls-cert
  rules:
  - host: app.example.com
    http:
      paths:
      - path: /api
        pathType: Prefix
        backend:
          service:
            name: api-service
            port:
              number: 80
      - path: /web
        pathType: Prefix
        backend:
          service:
            name: web-service
            port:
              number: 80
```

This routes:

- app.example.com/api → api-service
- app.example.com/web → web-service
- Uses TLS cert from tls-cert

### 🔐 TLS Termination

Ingress can handle HTTPS by referencing a TLS secret. This simplifies certificate management and offloads encryption from your app.

### 🧠 Best Practices

- ✅ Use IngressClass to specify which controller should handle your Ingress
- 🔁 Automate TLS with cert-manager and Let’s Encrypt
- 🛡️ Secure with annotations (rate limiting, auth, headers)
- 📊 Monitor with Prometheus, Grafana, or controller-specific dashboards

---

## 📐 What Are Resource Requests and Limits?

| Term    | Purpose                                   | Enforced When?         |
|---------|-------------------------------------------|------------------------|
| Request | Minimum resources a container is guaranteed| During scheduling      |
| Limit   | Maximum resources a container can consume | At runtime (via cgroups)|

- Requests help the scheduler place Pods on nodes with enough capacity.
- Limits prevent containers from hogging resources and impacting neighbors.

**Example YAML**

```yaml
resources:
  requests:
    cpu: "250m"
    memory: "64Mi"
  limits:
    cpu: "500m"
    memory: "128Mi"
```

This guarantees 250 millicores and 64Mi of memory, but caps usage at 500m CPU and 128Mi memory.

### 🧠 Behavior Differences

| Resource | If Exceeded Limit      | Notes                                 |
|----------|-----------------------|---------------------------------------|
| CPU      | Throttled (not killed)| Compressible; performance may degrade |
| Memory   | OOMKilled (terminated)| Non-compressible; container restarts  |

### 🔍 Why They Matter

- 🧭 Scheduling: Pods won’t be placed on nodes that can’t meet their requests.
- 🛡️ Stability: Prevents noisy neighbors and resource starvation.
- 💰 Cost Control: Avoids overprovisioning and wasted capacity.
- 📊 Autoscaling: HPA and VPA rely on accurate resource specs.

### 🛠️ Best Practices

- ✅ Always set both requests and limits—especially for memory.
- 📉 Start with conservative requests, then tune based on metrics.
- 🔁 Use tools like Goldilocks or VPA for recommendations.
- 🧪 Monitor with kubectl top, Prometheus, or Grafana.
- 🧭 Use LimitRange and ResourceQuota to enforce defaults and boundaries.

---

## 📊 Monitoring & Logging

### 🔹 Observability Stack

| Tool        | Function                        |
|-------------|---------------------------------|
| Prometheus  | Metric collection & alerts      |
| Grafana     | Dashboards & visualizations     |
| Fluent Bit  | Lightweight log forwarder       |
| Loki        | Log aggregation (Grafana Labs)  |
| ELK Stack   | Elasticsearch, Logstash, Kibana |

### 🔹 Setup Tips

- Use Helm charts for clean installs.
- Use DaemonSets for log agents to capture node-wide logs.
- Tail app logs with sidecar containers or node log collectors.

---

## ⏱ Jobs & CronJobs

### 🧪 Jobs: One-Time Task Execution

A Job ensures that a specified number of Pods run to completion. It’s perfect for batch processing, data transformation, or any task that should run once and exit.

#### 🔧 Key Features

- Creates Pods until the task completes successfully
- Retries failed Pods (based on backoffLimit)
- Supports parallel execution (completions, parallelism)
- Can run indexed tasks for distributed workloads

**Example:**

```yaml
apiVersion: batch/v1
kind: Job
metadata:
  name: data-migration
spec:
  template:
    spec:
      containers:
      - name: migrate
        image: busybox
        command: ["sh", "-c", "echo Migrating data..."]
      restartPolicy: OnFailure
```

### ⏰ CronJobs: Scheduled Jobs

A CronJob runs Jobs on a repeating schedule—just like Linux cron. Ideal for backups, report generation, or periodic cleanup.

#### 🔧 Key Features

- Uses standard cron syntax (*/5 * * * *)
- Creates Jobs at scheduled intervals
- Supports concurrency policies (Allow, Forbid, Replace)
- Can suspend execution (spec.suspend: true)
- Supports time zones (spec.timeZone)

**Example:**

```yaml
apiVersion: batch/v1
kind: CronJob
metadata:
  name: nightly-backup
spec:
  schedule: "0 2 * * *"  # Every day at 2 AM
  jobTemplate:
    spec:
      template:
        spec:
          containers:
          - name: backup
            image: busybox
            command: ["sh", "-c", "echo Running backup..."]
          restartPolicy: OnFailure
```

### 🧠 Best Practices

- ✅ Make Jobs idempotent—they may run more than once
- 🛡️ Use restartPolicy: OnFailure to retry failed tasks
- 🔍 Monitor with kubectl get jobs, kubectl logs, and kubectl describe
- 🧹 Clean up old Jobs with successfulJobsHistoryLimit and failedJobsHistoryLimit
- 🕵️ Use kubectl get cronjob to inspect schedules and status

---

## 🧠 What Is a CRD?

A Custom Resource Definition is a way to define new Kubernetes objects beyond the built-in ones like Pods, Services, and Deployments. Once registered, your custom resource behaves like any native object—accessible via kubectl, stored in etcd, and managed declaratively.

Think of CRDs as your way to say: “Hey Kubernetes, I want to manage this kind of thing too.”

### 📦 Example: Define a CRD

```yaml
apiVersion: apiextensions.k8s.io/v1
kind: CustomResourceDefinition
metadata:
  name: backups.mycompany.com
spec:
  group: mycompany.com
  versions:
  - name: v1
    served: true
    storage: true
    schema:
      openAPIV3Schema:
        type: object
        properties:
          spec:
            type: object
            properties:
              schedule:
                type: string
              retentionDays:
                type: integer
  scope: Namespaced
  names:
    plural: backups
    singular: backup
    kind: Backup
    shortNames:
    - bk
```

This creates a new resource type Backup under the group mycompany.com, with fields like schedule and retentionDays.

### 🧪 Create a Custom Resource

```yaml
apiVersion: mycompany.com/v1
kind: Backup
metadata:
  name: daily-backup
spec:
  schedule: "0 2 * * *"
  retentionDays: 7
```

Once the CRD is applied, you can manage instances like this using:

```sh
kubectl apply -f backup.yaml
kubectl get backups
```

### 🔁 CRDs + Controllers = Magic

CRDs define the schema, but to make them do something, you pair them with a custom controller or operator. This controller watches for changes and takes action—like provisioning a backup job when a new Backup resource appears.

This is the foundation of the Operator pattern, used by tools like:

- cert-manager (for TLS certs)
- ArgoCD (for GitOps)
- Prometheus Operator (for monitoring)

### 🧠 Best Practices

- ✅ Use OpenAPI schemas for validation
- 🛡️ Avoid using CRDs for large-scale data storage—stick to config/state
- 🔍 Monitor CRD health with `kubectl describe crd <name>`
- 🧩 Use .spec and .status fields to separate desired vs actual state
- 📦 Version your CRDs (v1, v2beta1, etc.) for compatibility

---

## 🧠 What Is an Operator?

An Operator is a Kubernetes-native application that:

- Watches for changes to a Custom Resource
- Reconciles desired state with actual state
- Automates Day-1 (install/configure) and Day-2 (upgrade/backup/failover) operations

It’s like hiring a mini DevOps engineer to manage your app—except it never sleeps and always follows best practices.

### 🔧 How Operators Work

- CRD defines a new resource type (e.g., KafkaCluster, Backup, RedisNode)
- Operator watches that resource using a control loop
- Operator takes action to create/update/delete underlying Kubernetes objects (Pods, PVCs, Services, etc.)

### 📦 Example Use Cases

| Operator Name        | Purpose                                 |
|----------------------|-----------------------------------------|
| Prometheus Operator  | Deploy and manage Prometheus stack      |
| Cert-manager         | Automate TLS cert issuance and renewal  |
| ArgoCD Operator      | GitOps-driven app deployment            |
| Postgres Operator    | Manage HA PostgreSQL clusters           |
| Kafka Operator       | Automate Kafka brokers, topics, ACLs    |

### 🛠️ Anatomy of an Operator

- CRD: Defines the schema for your custom resource
- Controller: Watches for changes and runs reconciliation logic
- Deployment: Runs the controller as a Pod in your cluster
- RBAC: Grants the controller access to manage resources

### 🧠 Best Practices

- ✅ Use OpenAPI schema in CRDs for validation
- 🔁 Implement .status fields to track actual state
- 🧪 Test reconciliation logic thoroughly—Operators can be destructive
- 📦 Package with Helm or Operator SDK for easy deployment
- 🛡️ Secure with RBAC and namespace scoping

**Build Your Own Operator?**

You can use frameworks like:

- Kubebuilder
- Operator SDK
- Kopf (Python)
- Java Operator SDK

---

## Most used common commands

### 🚀 Cluster & Context Management

| Command                                         | Description                                 |
|-------------------------------------------------|---------------------------------------------|
| kubectl config view                             | Show current kubeconfig settings            |
| kubectl config use-context <name>               | Switch to a different cluster context       |
| kubectl config set-context --current --namespace=<ns> | Set default namespace for current context   |
| kubectl cluster-info                            | Display cluster endpoint info               |

### 📦 Resource Creation & Updates

| Command                                         | Description                                 |
|-------------------------------------------------|---------------------------------------------|
| kubectl apply -f <file>                         | Create or update resources from YAML/JSON   |
| kubectl create -f <file>                        | Create resources from manifest              |
| kubectl edit <resource>/<name>                  | Edit live resource in default editor        |
| kubectl patch <resource>/<name> --patch <json>  | Apply partial updates to a resource         |

### 🔍 Viewing & Inspecting Resources

| Command                                         | Description                                 |
|-------------------------------------------------|---------------------------------------------|
| kubectl get <resource>                          | List resources (e.g., pods, svc, deploy)    |
| kubectl get <resource> -o wide                  | Show extended info                          |
| kubectl describe <resource>/<name>              | Detailed view of resource state             |
| kubectl explain <resource>                      | Show API schema and field descriptions      |

### 🧪 Debugging & Logs

| Command                                         | Description                                 |
|-------------------------------------------------|---------------------------------------------|
| kubectl logs <pod>                              | View logs from a pod                        |
| kubectl logs <pod> -c <container>               | Logs from specific container                |
| kubectl exec -it <pod> -- /bin/sh               | Open shell inside a container               |
| kubectl top pod                                 | Show pod resource usage                     |
| kubectl get events --sort-by=.metadata.creationTimestamp | View recent cluster events          |

### 🔁 Scaling & Rollouts

| Command                                         | Description                                 |
|-------------------------------------------------|---------------------------------------------|
| kubectl scale deploy <name> --replicas=<n>      | Change number of pod replicas               |
| kubectl rollout status deploy/<name>            | Check rollout progress                      |
| kubectl rollout undo deploy/<name>              | Roll back to previous deployment            |
| kubectl rollout restart deploy/<name>           | Restart deployment pods                     |

### 🔐 Access Control & Security

| Command                                         | Description                                 |
|-------------------------------------------------|---------------------------------------------|
| kubectl auth can-i <verb> <resource>            | Check RBAC permissions                      |
| kubectl get serviceaccount                      | List ServiceAccounts                        |
| kubectl get roles,rolebindings                  | View RBAC roles and bindings                |

### 🧹 Cleanup & Deletion

| Command                                         | Description                                 |
|-------------------------------------------------|---------------------------------------------|
| kubectl delete <resource>/<name>                | Delete a specific resource                  |
| kubectl delete -f <file>                        | Delete resources from manifest              |
| kubectl delete pod --grace-period=0 --force     | Force delete a stuck pod                    |

### 🧠 Bonus Tips

- Use `kubectl get all` to list all resources in a namespace.
- Use `-n <namespace>` to scope commands.
- Use `--field-selector` and `--selector` for fine-grained filtering.
- Use `-o yaml` or `-o json` for structured output.

---

## 🧠 What Is a Network Policy?

A NetworkPolicy is a Kubernetes resource that defines rules for ingress and egress traffic to/from Pods. By default, all traffic is allowed—until you apply a policy. Once active, only traffic that matches the policy is permitted.

Think of it as a firewall for your Pods, but smarter and label-driven.

### 🔧 Key Concepts

| Concept         | Description                                 |
|-----------------|---------------------------------------------|
| podSelector     | Targets Pods by label                       |
| policyTypes     | Ingress, Egress, or both                    |
| ingress/egress  | Rules for allowed sources/destinations/ports|
| namespaceSelector| Allows traffic from specific namespaces    |
| ipBlock         | Allows traffic from specific CIDR ranges    |

**Example: Deny All Ingress Except Frontend**

```yaml
apiVersion: networking.k8s.io/v1
kind: NetworkPolicy
metadata:
  name: db-policy
  namespace: app-ns
spec:
  podSelector:
    matchLabels:
      role: db
  policyTypes:
  - Ingress
  ingress:
  - from:
    - podSelector:
        matchLabels:
          role: frontend
    ports:
    - protocol: TCP
      port: 5432
```

This allows only Pods labeled role=frontend to access role=db Pods on port 5432.

### 🔐 Default Behavior

- No policy = all traffic allowed
- Any policy = default deny all, then allow explicitly
- Policies are additive—multiple policies can apply to a Pod

### 🛠️ Best Practices

- ✅ Start with a default deny policy, then allow traffic incrementally
- 🧪 Use labels consistently for targeting
- 🔍 Monitor with tools like Cilium or Calico for visibility
- 🛡️ Combine with RBAC and PodSecurity for layered defense

---

## Questions

### 🧠 1. What is Kubernetes and why is it used?

**Answer Structure:**

- **Definition:** Kubernetes is an open-source container orchestration platform for automating deployment, scaling, and management of containerized applications.
- **Use Case:** It abstracts infrastructure complexity and enables declarative configuration and automation.
- **Impact:** Improves scalability, fault tolerance, and operational efficiency across hybrid and multi-cloud environments.

### 🧱 2. Explain Kubernetes architecture.

**Answer Structure:**

- **Control Plane:** Manages cluster state via components like API Server, Scheduler, Controller Manager, and etcd.
- **Worker Nodes:** Run containerized workloads via kubelet, container runtime, and kube-proxy.
- **Communication:** API Server is the central hub; etcd stores cluster state; kubelet ensures desired state on nodes.

### 📦 3. What is a Pod in Kubernetes?

**Answer Structure:**

- **Definition:** The smallest deployable unit in Kubernetes, encapsulating one or more containers.
- **Use Case:** Containers in a pod share network and storage, enabling tight coupling.
- **Example:** Sidecar pattern—logging or proxy container alongside main app.

### 🔁 4. How does Kubernetes handle scaling?

**Answer Structure:**

- **Horizontal Scaling:** Via Horizontal Pod Autoscaler (HPA) based on CPU/memory metrics.
- **Vertical Scaling:** Adjusts resource limits/requests per pod.
- **Cluster Scaling:** Node autoscaling via cloud provider integration.

### 🔄 5. What is a Deployment in Kubernetes?

**Answer Structure:**

- **Purpose:** Manages stateless applications, supports rolling updates and rollbacks.
- **Components:** ReplicaSets ensure desired pod count; strategy defines update behavior.
- **Example YAML:**

```yaml
apiVersion: apps/v1
kind: Deployment
metadata:
  name: my-app
spec:
  replicas: 3
  strategy:
    type: RollingUpdate
```

### 🧭 6. What is a Service and how does it work?

**Answer Structure:**

- **Definition:** Abstracts access to pods, enabling stable networking.
- **Types:** ClusterIP (internal), NodePort (external), LoadBalancer (cloud-integrated), ExternalName.
- **Selector:** Matches pods via labels.

### 🔐 7. How does Kubernetes manage secrets and configuration?

**Answer Structure:**

- **ConfigMaps:** Store non-sensitive config data.
- **Secrets:** Store sensitive data like passwords, tokens.
- **Usage:** Mounted as volumes or injected as environment variables.

### 📊 8. What is etcd and why is it important?

**Answer Structure:**

- **Definition:** A distributed key-value store used by Kubernetes to store cluster state.
- **Role:** Ensures consistency and availability of configuration data.
- **Backup Strategy:** Regular snapshots and secure storage are critical.

### 🌐 9. What is Ingress in Kubernetes?

**Answer Structure:**

- **Purpose:** Manages external HTTP/S access to services.
- **Components:** Ingress resource + Ingress controller (e.g., NGINX).
- **Features:** Path-based routing, TLS termination, virtual hosting.

### 🧪 10. How do you monitor and debug Kubernetes clusters?

**Answer Structure:**

- **Monitoring Tools:** Prometheus, Grafana, cAdvisor.
- **Logging:** Fluentd, ELK/EFK stack.
- **Debugging:** `kubectl logs`, `kubectl describe`, `kubectl exec`.

### 🧩 11. What is a StatefulSet and when should you use it?

**Answer Structure:**

- **Definition:** A Kubernetes controller for managing stateful applications, ensuring stable identifiers and persistent storage.
- **Key Features:**
  - Persistent identity (`pod-0`, `pod-1`, etc.)
  - Ordered deployment and termination
  - Volume claims tied to pod identity
- **Use Case:** Databases (PostgreSQL, MongoDB), distributed caches (Redis), or systems requiring stable network IDs.

### 🧬 12. What are Custom Resource Definitions (CRDs)?

**Answer Structure:**

- **Definition:** CRDs extend Kubernetes API by allowing users to define new resource types.
- **Example:** Define a `KafkaTopic` resource that a controller reconciles.
- **Architecture:**
  - CRD + Controller = Operator pattern
  - Controller watches the CRD, reconciles desired state with actual state
- **Impact:** Enables domain-specific abstractions and lifecycle automation.

### 🌍 13. How would you design for multi-cluster or multi-region deployments?

**Answer Structure:**

- **Goals:** High availability, low latency, regional failover, data sovereignty.
- **Design Patterns:**
  - Federated clusters using KubeFed
  - Service Mesh (Istio) for cross-cluster communication
  - Global control plane, local data planes
- **Challenges:**
  - Secret and config management
  - Data consistency across clusters
  - Deployment orchestration and policy syncing

### 🧠 14. How do you handle persistent storage in Kubernetes?

**Answer Structure:**

- **Storage Classes:** Define types of storage (fast SSDs, network-attached volumes)
- **PersistentVolume (PV):** Represents provisioned storage
- **PersistentVolumeClaim (PVC):** Request for PVs by pods
- **Dynamic Provisioning:** Enables automatic volume creation
- **CSI Drivers:** Interface standard to integrate custom and cloud-native storage providers

### 🧱 15. How do you implement zero-downtime deployments?

**Answer Structure:**

- **Strategies:**
  - Rolling updates with health checks
  - Readiness probes to avoid traffic to unstable pods
  - Canary deployments for real traffic testing
  - Blue-Green deployments with switch-over control
- **Tools:** Argo Rollouts, Flagger, Linkerd
- **Monitoring:** Metrics and alerts for regressions

### 🔒 16. How do you manage security in Kubernetes?

**Answer Structure:**

- **RBAC (Role-Based Access Control):** Fine-grained access permissions
- **Network Policies:** Define allowed traffic between pods
- **Pod Security Standards:** Enforce policies like non-root users, read-only FS
- **Secrets Management:** Kubernetes secrets or external vaults (HashiCorp Vault)

### 🛠️ 17. How do you troubleshoot a failing pod?

**Answer Structure:**

- **Initial Steps:**
  - `kubectl get pod` for status
  - `kubectl describe pod` for events
  - `kubectl logs` to review app output
- **Advanced Tools:**
  - `kubectl exec` for interactive debugging
  - `stern` for streaming logs
  - Metrics from Prometheus/Grafana

### 🔄 18. What happens during a rolling update if a new image is pushed mid-deployment?

- **Answer:** Kubernetes interrupts the current rollout and starts a new one immediately. This can lead to temporary resource spikes and multiple ReplicaSets coexisting. Monitoring and rollback readiness are key.

### 🧱 19. How do you handle InitContainer failures with `restartPolicy: Never`?

- **Answer:** The Pod enters `Init:Error` or `Init:CrashLoopBackOff` and remains stuck. The main container won’t start. You must delete and recreate the Pod to recover.

### 🧭 20. Can multiple containers in a Pod bind to the same localhost port?

- **Answer:** No. Containers share the same network namespace. Only one can bind to a given port; others will fail with “port already in use.” Use sidecar patterns or distinct ports.

### 🧪 21. What happens if a ServiceAccount is deleted while Pods using it are still running?

- **Answer:** Existing Pods continue using cached tokens until they expire. New Pods can’t be created with the deleted ServiceAccount. Token refresh may fail, leading to auth errors.

### 🧬 22. How do you control Pod eviction timing when a node becomes `NotReady`?

- **Answer:** Default eviction timeout is 300s. You can override with `tolerationSeconds` in Pod spec. Use PodDisruptionBudgets to limit simultaneous evictions.

### 🧰 23. What’s the behavior of HPA when the metrics server is unavailable?

- **Answer:** HPA enters degraded mode—no scaling decisions are made. Replica count remains static. Once metrics resume, HPA may scale rapidly based on accumulated load.

### 🧱 24. Can StatefulSet Pods be renamed to maintain ordinal order after deletion?

- **Answer:** No. Deleted Pods are recreated with the same name. Existing Pods retain their ordinal identity to preserve stable network and volume bindings.

### 🧠 25. How do you debug a Pod in `CrashLoopBackOff`?

- **Answer:** Use `kubectl logs --previous`, `kubectl describe`, and `kubectl exec` if the container runs briefly. Temporarily disable probes or increase resource limits for deeper inspection.

### 🔒 26. How do you enforce security boundaries between namespaces?

- **Answer:** Use RBAC to restrict access, NetworkPolicies to isolate traffic, and Admission Controllers to enforce policies like non-root containers or image whitelisting.

### 🌐 27. How do you design a Kubernetes-native multi-tenant platform?

- **Answer:**
  - Isolate tenants via namespaces
  - Use ResourceQuotas and LimitRanges
  - Apply RBAC per tenant

---
