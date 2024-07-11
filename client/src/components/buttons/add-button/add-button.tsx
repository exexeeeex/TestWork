'use client';
import { IButton, IPassword, IPasswordType } from '@/interfaces';
import { ChangeEvent, FC, useEffect, useState } from 'react';
import { usePassword } from '@/hooks';
import styles from './add-button.module.scss';

const AddButton: FC<IButton> = ({ onClick, value }) => {
    const { getAllTypes, createPassword } = usePassword();

    const openModal = () => setIsOpen(true);
    const closeModal = () => setIsOpen(false);

    const [isOpen, setIsOpen] = useState(false);
    const [types, setTypes] = useState<IPasswordType[]>([]);
    const [passwordModel, setPasswordModel] = useState<IPassword>({
        id: '',
        name: '',
        value: '',
        createDate: '',
        passwordTypeId: '',
    });

    useEffect(() => {
        const typesData = async () => {
            const response: IPasswordType[] = await getAllTypes();
            setTypes(response);
            const site = response.find((item) => item.name.toLocaleLowerCase() === 'site')?.id;
            setPasswordModel({ ...passwordModel, passwordTypeId: site ? site : 'null' });
        };
        typesData();
    }, []);

    const handleRadioChange = (event: ChangeEvent<HTMLInputElement>) => {
        const selectedId = event.target.value;
        setPasswordModel({ ...passwordModel, passwordTypeId: selectedId });
    };

    const handleInputChange = (e: ChangeEvent<HTMLInputElement>) => {
        const { name, value } = e.target;
        setPasswordModel({ ...passwordModel, [name]: value });
    };

    const createNewPassword = async () => {
        await createPassword(passwordModel);
    };

    return (
        <div className={styles.modalContainer}>
            <button onClick={openModal} className={styles.openModalButton}>
                {value}
            </button>

            {isOpen && (
                <div className={`${styles.modal}`}>
                    <div className={`${styles.content}`}>
                        <h2>Добавить запись</h2>
                        {types &&
                            types.map((type) => (
                                <div
                                    key={type.id}
                                    style={{ display: 'flex', alignItems: 'center', gap: '20px' }}
                                >
                                    <input
                                        key={type.id}
                                        value={type.id}
                                        name='type'
                                        checked={passwordModel.passwordTypeId === type.id}
                                        onChange={handleRadioChange}
                                        content={`${type.name}`}
                                        type='radio'
                                    />
                                    <p>{type.name}</p>
                                </div>
                            ))}
                        <input
                            onChange={handleInputChange}
                            className={`${styles.input}`}
                            type='text'
                            name='name'
                            placeholder='Почта/Сайт'
                        />
                        <input
                            onChange={handleInputChange}
                            className={`${styles.input}`}
                            type='text'
                            name='value'
                            placeholder='Пароль'
                        />
                        <div className={`${styles.buttons}`}>
                            <button className={`${styles.button}`} onClick={createNewPassword}>
                                Применить
                            </button>
                            <button className={`${styles.button}`} onClick={closeModal}>
                                Отмена
                            </button>
                        </div>
                    </div>
                </div>
            )}
        </div>
    );
};

export default AddButton;
