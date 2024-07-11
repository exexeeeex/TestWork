'use client';
import { IPassword } from '@/interfaces';
import { useEffect, useState } from 'react';
import { usePassword } from '@/hooks';
import { PasswordCard } from '@/components/cards';
import { AddButton } from '@/components/buttons';
import styles from './password-place.module.scss';

const PasswordPlace = () => {
    const { getAll } = usePassword();

    const [passwords, setPasswords] = useState<IPassword[]>([]);

    useEffect(() => {
        const passwordFetchData = async () => setPasswords(await getAll());
        passwordFetchData();
    }, []);

    return (
        <>
            <main className={`${styles.main}`}>
                {passwords &&
                    passwords.map((password) => (
                        <PasswordCard
                            key={password.id}
                            id={password.id}
                            name={password.name}
                            value={password.value}
                            createDate={password.createDate}
                            passwordTypeId={password.passwordTypeId}
                        />
                    ))}
            </main>
            <AddButton value={`Добавить`} onClick={undefined} />
        </>
    );
};

export default PasswordPlace;
