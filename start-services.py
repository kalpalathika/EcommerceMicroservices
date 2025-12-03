#!/usr/bin/env python3
"""
Simple script to start all microservices
Usage:
    python start-services.py          # Run with 'dotnet run'
    python start-services.py --watch  # Run with 'dotnet watch'
"""

import subprocess
import sys
import os
import signal

SERVICES = [
    'Services/Ecommerce.Services.AuthAPI',
    'Services/Ecommerce.Services.ProductAPI',
    'Services/Ecommerce.Services.ShoppingCartAPI',
    'Services/Ecommerce.Services.OrderAPI',
    'Services/Ecommerce.Services.CouponAPI',
    'Services/Ecommerce.Services.EmailAPI',
    'FrontEnd/Ecommerce.Web'
]

processes = []

def start_services(use_watch=False):
    """Start all services"""
    cmd = ['dotnet', 'watch'] if use_watch else ['dotnet', 'run']

    print(f"\nStarting {len(SERVICES)} services with '{' '.join(cmd)}'...\n")

    for service_path in SERVICES:
        service_name = os.path.basename(service_path)
        print(f"Starting {service_name}...")

        process = subprocess.Popen(
            cmd,
            cwd=service_path,
            stdout=subprocess.DEVNULL,
            stderr=subprocess.DEVNULL
        )
        processes.append(process)

    print(f"\n✓ All services started!")

def cleanup():
    """Stop all services"""
    print("\nStopping services...")
    for process in processes:
        process.terminate()
    print("✓ All services stopped\n")

def signal_handler(sig, frame):
    cleanup()
    sys.exit(0)

if __name__ == '__main__':
    signal.signal(signal.SIGINT, signal_handler)

    use_watch = '--watch' in sys.argv
    start_services(use_watch)

    # Wait forever
    signal.pause()
